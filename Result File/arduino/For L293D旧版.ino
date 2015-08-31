#include <Servo.h>
#include <DistanceSRF04.h>
#include <Wire.h>
#include <AFMotor.h>

// 声明马达
AF_DCMotor Motor_FrontRight(1);
AF_DCMotor Motor_BackRight(2);
AF_DCMotor Motor_FrontLeft(3);
AF_DCMotor Motor_BackLeft(4);

//马达速度
byte Motor_FrontRightSpeed = 0;
byte Motor_BackRightSpeed = 0;
byte Motor_FrontLeftSpeed = 0;
byte Motor_BackLeftSpeed = 0;
//马达方向
// FORWARD 1
// BACKWARD 2
// BRAKE 3
// RELEASE 4
byte Motor_FrontRightDirection = RELEASE;
byte Motor_BackRightDirection = RELEASE;
byte Motor_FrontLeftDirection = RELEASE;
byte Motor_BackLeftDirection = RELEASE;

//是否开启雷达
byte radar = false;

//是否开启灯光，完全没打算做。。懒，可自行增加LED1,LED2的口就是计划使用的接口
byte light = false;

//两个舵机的居中角度。
byte servoXCenterPoint = 98;
byte servoYCenterPoint = 88 ;
//两个舵机的最大角度
byte servoXmax = 170;
byte servoYmax = 126;
//两个舵机的最小角度
byte servoXmini = 10;
byte servoYmini = 10;
//两个舵机的当前角度，用于回传，也不用再读取计算，节约资源
byte servoXPoint = 0;
byte servoYPoint = 0;
//舵机每转动一次的角度递增值
byte servoStep = 4;

//雷达
DistanceSRF04 Dist;
int distance;

Servo servoX;
Servo servoY;

int LED1 = 2;
int LaBa = 13;

byte serialIn = 0;
byte commandAvailable = false;
String strReceived = "";

void setup() {
  Serial.begin(115200);
  Serial.println("Motor party!");

  Dist.begin(15, 14); //雷达信号口
  servoX.attach(9);//1号舵机信号口
  servoY.attach(10);//2号舵机信号口

  pinMode(LED1, OUTPUT);
  pinMode(LaBa, OUTPUT);


  Motor_FrontRight.run(Motor_FrontRightDirection);
  Motor_BackRight.run(Motor_BackRightDirection);
  Motor_FrontLeft.run(Motor_FrontLeftDirection);
  Motor_BackLeft.run(Motor_BackLeftDirection);

  servo_test();//舵机测试
}

// Test the DC motor, stepper and servo ALL AT ONCE!
void loop() {

  //Motor_BackRight.setSpeed(254);
  //Motor_FrontLeft.setSpeed(254);
  //Motor_BackLeft.setSpeed(254);
  //Motor_BackRight.run(FORWARD);
  //Motor_FrontLeft.run(FORWARD);
  //Motor_BackLeft.run(FORWARD);
  if (radar == true)
  {
    //distance = Dist.getDistanceCentimeter();

   // if (distance <= 3 & distance > 0) {
    //  Motor_FrontRightSpeed = 255;
    //  Motor_BackRightSpeed = 255;
    //  Motor_FrontLeftSpeed = 255;
     // Motor_BackLeftSpeed = 255;
     // qian();
    //  delay(100);
    //  ting();
    //  distance = 0;
    //}
  }
  getSerialLine();
  if (commandAvailable) {
    processCommand(strReceived);
    strReceived = "";
    commandAvailable = false;
  }

}


void getSerialLine()
{
  //使用\r字符作为两条命令间隔符，拼接收到的字符
  while (serialIn != '\r')
  {
    if (!(Serial.available() > 0))
    {
      return;
    }
    serialIn = Serial.read();
    if (serialIn != '\r') {
      //对于某些语言可能无法单独输出\r 忽略后续的\n字符符
      if (serialIn != '\n') {
        char a = char(serialIn);
        strReceived += a;
      }

    }
  }
  //读取到分割符，重新启动拼接
  if (serialIn == '\r') {
    commandAvailable = true;
    serialIn = 0;
  }

}
///
//命令处理过程
//建议所有的命令识别都在这里完成。每个动作独立方法，不要在里面写操作过程，这样看起来比较清晰。
///
void processCommand(String input)
{
  String command = getValue(input, ' ', 0);
  byte iscommand = true;
  int val;
  if (command == "MD_Qian")
  {
    qian();
  }
  else if (command == "MD_Hou")
  {
    hou();
  }
  else if (command == "MD_Zuo")
  {
    zuo();
  }
  else if (command == "MD_You")
  {
    you();
  }
  else if (command == "MD_Ting")
  {
    ting();
  }
  else if (command == "MD_SD")
  {
    val = getValue(input, ' ', 1).toInt();
    Motor_FrontLeftSpeed = val;
    Motor_BackLeftSpeed = val;
    val = getValue(input, ' ', 2).toInt();
    Motor_FrontRightSpeed = val;
    Motor_BackRightSpeed = val;
  }
  else if (command == "DJ_CS")
  {
    servo_test();
  }
  else if (command == "DJ_Shang")
  {
    servo_up();
  }
  else if (command == "DJ_Xia")
  {
    servo_down();
  }
  else if (command == "DJ_Zuo")
  {
    servo_left();
  }
  else if (command == "DJ_You")
  {
    servo_right();
  }
  else if (command == "DJ_Zhong")
  {
    servo_center();
  }
  else if (command == "DJ_CZ_JD")//VerticalRotation
  {
    val = getValue(input, ' ', 1).toInt();
  }
  else if (command == "DJ_SP_JD")//Horizontal rotation
  {
    val = getValue(input, ' ', 1).toInt();
  }
  else if (command == "LED_Status")
  {
    val = getValue(input, ' ', 1).toInt();
    light = val == 0 ? false : true;
    SetLight(light);
  }
  else if (command == "LED_Status_Swich")
  {
    light = light ? false : true;
    SetLight(light);
  }
  else if (command == "Radar_Status")
  {
    val = getValue(input, ' ', 1).toInt();
    radar = val ? true : false;
  }
  else if (command == "Radar_Status_Swich")
  {
    radar = radar ? false : true;
  }
  else if (command == "LaBa_Start") {
    SetLaBa(true);
  }
  else if (command == "LaBa_Stop") {
    SetLaBa(false);
  }
  else if (command == "Status") {
   SendStatus();
  }
  else
  {
    iscommand = false;
  }
  //是否收到的是已经定义的命令，如果不是则不回送状态，免得浪费带宽
  if (iscommand) {
    SendMessage("cmd:" + input);
    SendStatus();
  }

}
//命令参数获取方法，支持一个命令多个参数，采用空格符作为分割符号，注意是半角空格符，不是制表符也不是全角空格，可或者可以自行定义，并修改，懒改了。
String getValue(String data, char separator, int index)
{
  int found = 0;
  int strIndex[] = {
    0, -1
  };
  int maxIndex = data.length() - 1;

  for (int i = 0; i <= maxIndex && found <= index; i++) {
    if (data.charAt(i) == separator || i == maxIndex) {
      found++;
      strIndex[0] = strIndex[1] + 1;
      strIndex[1] = (i == maxIndex) ? i + 1 : i;
    }
  }

  return found > index ? data.substring(strIndex[0], strIndex[1]) : "";
}

//舵机动作部分，字面意思你懂的。。。
void servo_test(void) {
  int nowcornerY = servoY.read();
  int nowcornerX = servoX.read();
  servo_Vertical(servoYmini);
  delay(500);
  servo_Vertical(servoYmax);
  delay(500);
  servo_Vertical(servoYCenterPoint);
  delay(500);
  servo_Horizontal(servoXmini);
  delay(500);
  servo_Horizontal(servoXmax);
  delay(500);
  servo_Horizontal(servoXCenterPoint);
  delay(500);
  servo_center();
}
void servo_right(void)
{
  int servotemp = servoX.read();
  servotemp -= servoStep;
  servo_Horizontal(servotemp);
}
void servo_left(void)
{
  int servotemp = servoX.read();
  servotemp += servoStep;
  servo_Horizontal(servotemp);
}
void servo_down(void)
{
  int servotemp = servoY.read();
  servotemp += servoStep;
  servo_Vertical(servotemp);
}
void servo_up(void)
{
  int servotemp = servoY.read();
  servotemp -= servoStep;
  servo_Vertical(servotemp);
}
void servo_center(void)
{
  servo_Vertical(servoYCenterPoint);
  servo_Horizontal(servoXCenterPoint);
}
void servo_Vertical(int corner)
{
  int cornerY = servoY.read();
  if (cornerY > corner) {
    for (int i = cornerY; i > corner; i = i - servoStep) {
      servoY.write(i);
      servoYPoint = i;
      delay(50);
    }
  }
  else {
    for (int i = cornerY; i < corner; i = i + servoStep) {
      servoY.write(i);
      servoYPoint = i;
      delay(50);
    }
  }
  servoY.write(corner);
  servoYPoint = corner;
}
void servo_Horizontal(int corner)
{
  int i = 0;
  byte cornerX = servoX.read();
  if (cornerX > corner) {
    for (i = cornerX; i > corner; i = i - servoStep) {
      servoX.write(i);
      servoXPoint = i;
      delay(50);
    }
  }
  else {
    for (i = cornerX; i < corner; i = i + servoStep) {
      servoX.write(i);
      servoXPoint = i;
      delay(50);
    }
  }
  servoX.write(corner);
  servoXPoint = corner;
}
//电机方向动作部分，中文拼音大声念出来就是意思了。。
void qian(void)
{

  Motor_FrontRightDirection = FORWARD;
  Motor_BackRightDirection = FORWARD;
  Motor_FrontLeftDirection = FORWARD;
  Motor_BackLeftDirection = FORWARD;
  SetEN();

}
void hou(void)
{

  Motor_FrontRightDirection = BACKWARD;
  Motor_BackRightDirection = BACKWARD;
  Motor_FrontLeftDirection = BACKWARD;
  Motor_BackLeftDirection = BACKWARD;
  SetEN();
}
void you(void)
{
  Motor_FrontRightDirection = BACKWARD;
  Motor_BackRightDirection = BACKWARD;
  Motor_FrontLeftDirection = FORWARD;
  Motor_BackLeftDirection = FORWARD;
  SetEN();
}
void zuo(void)
{
  Motor_FrontRightDirection = FORWARD;
  Motor_BackRightDirection = FORWARD;
  Motor_FrontLeftDirection = BACKWARD;
  Motor_BackLeftDirection = BACKWARD;
  SetEN();
}
void ting(void)
{
  Motor_FrontRightSpeed = 0;
  Motor_BackRightSpeed = 0;
  Motor_FrontLeftSpeed = 0;
  Motor_BackLeftSpeed = 0;

  Motor_FrontRightDirection = RELEASE;
  Motor_BackRightDirection = RELEASE;
  Motor_FrontLeftDirection = RELEASE;
  Motor_BackLeftDirection = RELEASE;
  SetEN();
}
//设置速度
void SetEN() {
  Motor_FrontRight.setSpeed(Motor_FrontRightSpeed);
  Motor_BackRight.setSpeed(Motor_BackRightSpeed);
  Motor_FrontLeft.setSpeed(Motor_FrontLeftSpeed);
  Motor_BackLeft.setSpeed(Motor_BackLeftSpeed);
  Motor_FrontRight.run(Motor_FrontRightDirection);
  Motor_BackRight.run(Motor_BackRightDirection);
  Motor_FrontLeft.run(Motor_FrontLeftDirection);
  Motor_BackLeft.run(Motor_BackLeftDirection);

}

//灯光开关
void SetLight(bool status) {
  digitalWrite(LED1, status);
}
void SetLaBa(bool status) {
  if (status)
    digitalWrite(LaBa, HIGH);//发声音
  else
    digitalWrite(LaBa, LOW);
}


//拼接状态
void SendStatus() {
  String out = "";
  out += Motor_FrontLeftDirection;
  out += ",";
  out += Motor_FrontRightDirection;
  out += ",";
  out += Motor_BackRightDirection;
  out += ",";
  out += Motor_BackLeftDirection;
  out += ",";
  out += Motor_FrontLeftSpeed;
  out += ",";
  out += Motor_FrontRightSpeed;
  out += ",";
  out += servoXPoint;
  out += ",";
  out += servoYPoint;
  out += ",";
  out += radar;
  out += ",";
  out += light;
  SendMessage(out);
}
//串口消息发送
void SendMessage(String data) {
  Serial.println(data);
}


