#include <Servo.h>    
#include <DistanceSRF04.h>
#include <Wire.h>
#include <LiquidCrystal_I2C.h>


DistanceSRF04 Dist;
LiquidCrystal_I2C lcd(0x27, 16, 2);//声明LCD，用于显示文字的。
int distance;
int EN1 = 14;
int EN2 = 15;
int EN3 = 16;
int EN4 = 17;

int LED1 = 2;
int LED2 = 4;
int EA = 3;
int EB = 5;

int LaBa = 12;


//四个马达的电平状态
uint8_t EN1Status = LOW;
uint8_t EN2Status = LOW;
uint8_t EN3Status = LOW;
uint8_t EN4Status = LOW;

Servo servoX;
Servo servoY;


byte serialIn = 0;
byte commandAvailable = false;
String strReceived = "";
//是否开启雷达，我的坏了。雷达部分已经注释掉。可自己启用
byte radar = false;
//是否开启灯光，完全没打算做。。懒，可自行增加LED1,LED2的口就是计划使用的接口
byte light = false;
//两个舵机的居中角度。
byte servoXCenterPoint = 94;
byte servoYCenterPoint = 88 ;
//两个舵机的最大角度
byte servoXmax = 170;
byte servoYmax = 130;
//两个舵机的最小角度
byte servoXmini = 10;
byte servoYmini = 10;
//两个舵机的当前角度，用于回传，也不用再读取计算，节约资源
byte servoXPoint = 0;
byte servoYPoint = 0;
//左右两侧的马达当前速度值
byte leftspeed = 0;
byte rightspeed = 0;
//舵机每转动一次的角度递增值
byte servoStep = 4;

///声明部分结束，注意，很多用的byte，如果大于255的还是用int



void setup()
{
	lcd.init();
	lcd.init();
	lcd.backlight();

	//lcd测试
	lcd.setCursor(0, 0);
	lcd.print("System starting!");


	Dist.begin(9,8);//雷达信号口

	servoX.attach(10);//1号舵机信号口
	servoY.attach(11);//2号舵机信号口

	pinMode(EN1, OUTPUT);
	pinMode(EN2, OUTPUT);
	pinMode(EN3, OUTPUT);
	pinMode(EN4, OUTPUT);

	pinMode(LED1, OUTPUT);
	pinMode(LED2, OUTPUT);
	pinMode(LaBa, OUTPUT); 

	lcd.setCursor(0, 1);
	lcd.print("test engine......");
	servo_test();//舵机测试

	Serial.begin(115200);
	lcd.clear();
	lcd.setCursor(0, 0);
	lcd.print("Welcome!");
	lcd.setCursor(0, 1);
	lcd.print("smart car system");
}


void loop()
{
	if (radar == true)
	{
		distance = Dist.getDistanceCentimeter();
		if (distance <= 5 & distance > 1){
			lcd.setCursor(0, 1);
			lcd.println("Warning back");
			hou();
			delay(100);
			ting();
			distance = 0;
		}
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
			if (serialIn != '\n'){
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
		leftspeed = val;
		val = getValue(input, ' ', 2).toInt();
		rightspeed = val;
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
	else if (command == "LaBa_Start"){
		SetLaBa(true);
	}
	else if (command == "LaBa_Stop"){
		SetLaBa(false);
	}
	else
	{
		iscommand = false;
	}
	//是否收到的是已经定义的命令，如果不是则不回送状态，免得浪费带宽
	if (iscommand){
		SendMessage("cmd:" + input);
		SendStatus();
	}
	
}
//命令参数获取方法，支持一个命令多个参数，采用空格符作为分割符号，注意是半角空格符，不是制表符也不是全角空格，可或者可以自行定义，并修改，懒改了。
String getValue(String data, char separator, int index)
{
	int found = 0;
	int strIndex[] = {
		0, -1 };
	int maxIndex = data.length() - 1;

	for (int i = 0; i <= maxIndex && found <= index; i++){
		if (data.charAt(i) == separator || i == maxIndex){
			found++;
			strIndex[0] = strIndex[1] + 1;
			strIndex[1] = (i == maxIndex) ? i + 1 : i;
		}
	}

	return found>index ? data.substring(strIndex[0], strIndex[1]) : "";
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
	EN1Status = LOW;
	EN2Status = HIGH;
	EN3Status = LOW;
	EN4Status = HIGH;
	SetEN();
}
void hou(void)
{
	EN1Status = HIGH;
	EN2Status = LOW;
	EN3Status = HIGH;
	EN4Status = LOW;
	SetEN();
}
void you(void)
{
	EN1Status = LOW;
	EN2Status = HIGH;
	EN3Status = HIGH;
	EN4Status = LOW;
	SetEN();
}
void zuo(void)
{
	EN1Status = HIGH;
	EN2Status = LOW;
	EN3Status = LOW;
	EN4Status = HIGH;
	SetEN();
}
void ting(void)
{
	leftspeed = 0;
	rightspeed = 0;
	EN1Status = LOW;
	EN2Status = LOW;
	EN3Status = LOW;
	EN4Status = LOW;
	SetEN();
}
//设置两侧速度
void SetEN(){
	analogWrite(EA, leftspeed);
	analogWrite(EB, rightspeed);
	digitalWrite(EN1, EN1Status);
	digitalWrite(EN2, EN2Status);
	digitalWrite(EN3, EN3Status);
	digitalWrite(EN4, EN4Status);
}

//灯光开关
void SetLight(bool status){
	digitalWrite(LED1, status);
	digitalWrite(LED2, status);
}
void SetLaBa(bool status){
	if (status)
		digitalWrite(LaBa, HIGH);//发声音
	else
		digitalWrite(LaBa, LOW);
}


//拼接状态
void SendStatus(){

	String out = "";
	out += EN1Status;
	out += ",";
	out += EN2Status;
	out += ",";
	out += EN3Status;
	out += ",";
	out += EN4Status;
	out += ",";
	out += leftspeed;
	out += ",";
	out += rightspeed;
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
void SendMessage(String data){
	Serial.println(data);
}
