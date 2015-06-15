package com.iha.wcc.fragment.network;

/**
 * This interface must be implemented by activities that contain this fragment to allow an interaction in this fragment to be communicated to the activity
 * and potentially other fragments contained in that activity.
 * <p>
 * See the Android Training lesson <a href= "http://developer.android.com/training/basics/fragments/communicating.html" >Communicating with Other
 * Fragments</a> for more information.
 * @deprecated Not used anymore but could be useful if the application was improved with the selection of the network as main page.
 */
public interface INetworkFragmentInteractionListener {
	public void onNetworkFragmentInteraction(String name, String ip);
}
