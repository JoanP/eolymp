package md524c35fc9321c9ac530e14a1496cfd61c;


public class couchBase_Android
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("eolymp.Droid.couchBase_Android, eolymp.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", couchBase_Android.class, __md_methods);
	}


	public couchBase_Android () throws java.lang.Throwable
	{
		super ();
		if (getClass () == couchBase_Android.class)
			mono.android.TypeManager.Activate ("eolymp.Droid.couchBase_Android, eolymp.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
