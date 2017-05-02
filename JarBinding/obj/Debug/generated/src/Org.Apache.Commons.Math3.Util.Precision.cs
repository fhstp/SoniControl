using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Apache.Commons.Math3.Util {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']"
	[global::Android.Runtime.Register ("org/apache/commons/math3/util/Precision", DoNotGenerateAcw=true)]
	public partial class Precision : global::Java.Lang.Object {


		static IntPtr EPSILON_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/field[@name='EPSILON']"
		[Register ("EPSILON")]
		public static double Epsilon {
			get {
				if (EPSILON_jfieldId == IntPtr.Zero)
					EPSILON_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "EPSILON", "D");
				return JNIEnv.GetStaticDoubleField (class_ref, EPSILON_jfieldId);
			}
		}

		static IntPtr SAFE_MIN_jfieldId;

		// Metadata.xml XPath field reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/field[@name='SAFE_MIN']"
		[Register ("SAFE_MIN")]
		public static double SafeMin {
			get {
				if (SAFE_MIN_jfieldId == IntPtr.Zero)
					SAFE_MIN_jfieldId = JNIEnv.GetStaticFieldID (class_ref, "SAFE_MIN", "D");
				return JNIEnv.GetStaticDoubleField (class_ref, SAFE_MIN_jfieldId);
			}
		}
		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/apache/commons/math3/util/Precision", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (Precision); }
		}

		protected Precision (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_compareTo_DDD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='compareTo' and count(parameter)=3 and parameter[1][@type='double'] and parameter[2][@type='double'] and parameter[3][@type='double']]"
		[Register ("compareTo", "(DDD)I", "")]
		public static unsafe int CompareTo (double p0, double p1, double p2)
		{
			if (id_compareTo_DDD == IntPtr.Zero)
				id_compareTo_DDD = JNIEnv.GetStaticMethodID (class_ref, "compareTo", "(DDD)I");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_compareTo_DDD, __args);
			} finally {
			}
		}

		static IntPtr id_compareTo_DDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='compareTo' and count(parameter)=3 and parameter[1][@type='double'] and parameter[2][@type='double'] and parameter[3][@type='int']]"
		[Register ("compareTo", "(DDI)I", "")]
		public static unsafe int CompareTo (double p0, double p1, int p2)
		{
			if (id_compareTo_DDI == IntPtr.Zero)
				id_compareTo_DDI = JNIEnv.GetStaticMethodID (class_ref, "compareTo", "(DDI)I");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_compareTo_DDI, __args);
			} finally {
			}
		}

		static IntPtr id_equals_DD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='equals' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='double']]"
		[Register ("equals", "(DD)Z", "")]
		public static unsafe bool Equals (double p0, double p1)
		{
			if (id_equals_DD == IntPtr.Zero)
				id_equals_DD = JNIEnv.GetStaticMethodID (class_ref, "equals", "(DD)Z");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_equals_DD, __args);
			} finally {
			}
		}

		static IntPtr id_equals_DDD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='equals' and count(parameter)=3 and parameter[1][@type='double'] and parameter[2][@type='double'] and parameter[3][@type='double']]"
		[Register ("equals", "(DDD)Z", "")]
		public static unsafe bool Equals (double p0, double p1, double p2)
		{
			if (id_equals_DDD == IntPtr.Zero)
				id_equals_DDD = JNIEnv.GetStaticMethodID (class_ref, "equals", "(DDD)Z");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_equals_DDD, __args);
			} finally {
			}
		}

		static IntPtr id_equals_DDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='equals' and count(parameter)=3 and parameter[1][@type='double'] and parameter[2][@type='double'] and parameter[3][@type='int']]"
		[Register ("equals", "(DDI)Z", "")]
		public static unsafe bool Equals (double p0, double p1, int p2)
		{
			if (id_equals_DDI == IntPtr.Zero)
				id_equals_DDI = JNIEnv.GetStaticMethodID (class_ref, "equals", "(DDI)Z");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_equals_DDI, __args);
			} finally {
			}
		}

		static IntPtr id_equals_FF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='equals' and count(parameter)=2 and parameter[1][@type='float'] and parameter[2][@type='float']]"
		[Register ("equals", "(FF)Z", "")]
		public static unsafe bool Equals (float p0, float p1)
		{
			if (id_equals_FF == IntPtr.Zero)
				id_equals_FF = JNIEnv.GetStaticMethodID (class_ref, "equals", "(FF)Z");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_equals_FF, __args);
			} finally {
			}
		}

		static IntPtr id_equals_FFF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='equals' and count(parameter)=3 and parameter[1][@type='float'] and parameter[2][@type='float'] and parameter[3][@type='float']]"
		[Register ("equals", "(FFF)Z", "")]
		public static unsafe bool Equals (float p0, float p1, float p2)
		{
			if (id_equals_FFF == IntPtr.Zero)
				id_equals_FFF = JNIEnv.GetStaticMethodID (class_ref, "equals", "(FFF)Z");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_equals_FFF, __args);
			} finally {
			}
		}

		static IntPtr id_equals_FFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='equals' and count(parameter)=3 and parameter[1][@type='float'] and parameter[2][@type='float'] and parameter[3][@type='int']]"
		[Register ("equals", "(FFI)Z", "")]
		public static unsafe bool Equals (float p0, float p1, int p2)
		{
			if (id_equals_FFI == IntPtr.Zero)
				id_equals_FFI = JNIEnv.GetStaticMethodID (class_ref, "equals", "(FFI)Z");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_equals_FFI, __args);
			} finally {
			}
		}

		static IntPtr id_equalsIncludingNaN_DD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='equalsIncludingNaN' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='double']]"
		[Register ("equalsIncludingNaN", "(DD)Z", "")]
		public static unsafe bool EqualsIncludingNaN (double p0, double p1)
		{
			if (id_equalsIncludingNaN_DD == IntPtr.Zero)
				id_equalsIncludingNaN_DD = JNIEnv.GetStaticMethodID (class_ref, "equalsIncludingNaN", "(DD)Z");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_equalsIncludingNaN_DD, __args);
			} finally {
			}
		}

		static IntPtr id_equalsIncludingNaN_DDD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='equalsIncludingNaN' and count(parameter)=3 and parameter[1][@type='double'] and parameter[2][@type='double'] and parameter[3][@type='double']]"
		[Register ("equalsIncludingNaN", "(DDD)Z", "")]
		public static unsafe bool EqualsIncludingNaN (double p0, double p1, double p2)
		{
			if (id_equalsIncludingNaN_DDD == IntPtr.Zero)
				id_equalsIncludingNaN_DDD = JNIEnv.GetStaticMethodID (class_ref, "equalsIncludingNaN", "(DDD)Z");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_equalsIncludingNaN_DDD, __args);
			} finally {
			}
		}

		static IntPtr id_equalsIncludingNaN_DDI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='equalsIncludingNaN' and count(parameter)=3 and parameter[1][@type='double'] and parameter[2][@type='double'] and parameter[3][@type='int']]"
		[Register ("equalsIncludingNaN", "(DDI)Z", "")]
		public static unsafe bool EqualsIncludingNaN (double p0, double p1, int p2)
		{
			if (id_equalsIncludingNaN_DDI == IntPtr.Zero)
				id_equalsIncludingNaN_DDI = JNIEnv.GetStaticMethodID (class_ref, "equalsIncludingNaN", "(DDI)Z");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_equalsIncludingNaN_DDI, __args);
			} finally {
			}
		}

		static IntPtr id_equalsIncludingNaN_FF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='equalsIncludingNaN' and count(parameter)=2 and parameter[1][@type='float'] and parameter[2][@type='float']]"
		[Register ("equalsIncludingNaN", "(FF)Z", "")]
		public static unsafe bool EqualsIncludingNaN (float p0, float p1)
		{
			if (id_equalsIncludingNaN_FF == IntPtr.Zero)
				id_equalsIncludingNaN_FF = JNIEnv.GetStaticMethodID (class_ref, "equalsIncludingNaN", "(FF)Z");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_equalsIncludingNaN_FF, __args);
			} finally {
			}
		}

		static IntPtr id_equalsIncludingNaN_FFF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='equalsIncludingNaN' and count(parameter)=3 and parameter[1][@type='float'] and parameter[2][@type='float'] and parameter[3][@type='float']]"
		[Register ("equalsIncludingNaN", "(FFF)Z", "")]
		public static unsafe bool EqualsIncludingNaN (float p0, float p1, float p2)
		{
			if (id_equalsIncludingNaN_FFF == IntPtr.Zero)
				id_equalsIncludingNaN_FFF = JNIEnv.GetStaticMethodID (class_ref, "equalsIncludingNaN", "(FFF)Z");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_equalsIncludingNaN_FFF, __args);
			} finally {
			}
		}

		static IntPtr id_equalsIncludingNaN_FFI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='equalsIncludingNaN' and count(parameter)=3 and parameter[1][@type='float'] and parameter[2][@type='float'] and parameter[3][@type='int']]"
		[Register ("equalsIncludingNaN", "(FFI)Z", "")]
		public static unsafe bool EqualsIncludingNaN (float p0, float p1, int p2)
		{
			if (id_equalsIncludingNaN_FFI == IntPtr.Zero)
				id_equalsIncludingNaN_FFI = JNIEnv.GetStaticMethodID (class_ref, "equalsIncludingNaN", "(FFI)Z");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_equalsIncludingNaN_FFI, __args);
			} finally {
			}
		}

		static IntPtr id_equalsWithRelativeTolerance_DDD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='equalsWithRelativeTolerance' and count(parameter)=3 and parameter[1][@type='double'] and parameter[2][@type='double'] and parameter[3][@type='double']]"
		[Register ("equalsWithRelativeTolerance", "(DDD)Z", "")]
		public static unsafe bool EqualsWithRelativeTolerance (double p0, double p1, double p2)
		{
			if (id_equalsWithRelativeTolerance_DDD == IntPtr.Zero)
				id_equalsWithRelativeTolerance_DDD = JNIEnv.GetStaticMethodID (class_ref, "equalsWithRelativeTolerance", "(DDD)Z");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticBooleanMethod  (class_ref, id_equalsWithRelativeTolerance_DDD, __args);
			} finally {
			}
		}

		static IntPtr id_representableDelta_DD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='representableDelta' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='double']]"
		[Register ("representableDelta", "(DD)D", "")]
		public static unsafe double RepresentableDelta (double p0, double p1)
		{
			if (id_representableDelta_DD == IntPtr.Zero)
				id_representableDelta_DD = JNIEnv.GetStaticMethodID (class_ref, "representableDelta", "(DD)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_representableDelta_DD, __args);
			} finally {
			}
		}

		static IntPtr id_round_DI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='round' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='int']]"
		[Register ("round", "(DI)D", "")]
		public static unsafe double Round (double p0, int p1)
		{
			if (id_round_DI == IntPtr.Zero)
				id_round_DI = JNIEnv.GetStaticMethodID (class_ref, "round", "(DI)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_round_DI, __args);
			} finally {
			}
		}

		static IntPtr id_round_DII;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='round' and count(parameter)=3 and parameter[1][@type='double'] and parameter[2][@type='int'] and parameter[3][@type='int']]"
		[Register ("round", "(DII)D", "")]
		public static unsafe double Round (double p0, int p1, int p2)
		{
			if (id_round_DII == IntPtr.Zero)
				id_round_DII = JNIEnv.GetStaticMethodID (class_ref, "round", "(DII)D");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_round_DII, __args);
			} finally {
			}
		}

		static IntPtr id_round_FI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='round' and count(parameter)=2 and parameter[1][@type='float'] and parameter[2][@type='int']]"
		[Register ("round", "(FI)F", "")]
		public static unsafe float Round (float p0, int p1)
		{
			if (id_round_FI == IntPtr.Zero)
				id_round_FI = JNIEnv.GetStaticMethodID (class_ref, "round", "(FI)F");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticFloatMethod  (class_ref, id_round_FI, __args);
			} finally {
			}
		}

		static IntPtr id_round_FII;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='Precision']/method[@name='round' and count(parameter)=3 and parameter[1][@type='float'] and parameter[2][@type='int'] and parameter[3][@type='int']]"
		[Register ("round", "(FII)F", "")]
		public static unsafe float Round (float p0, int p1, int p2)
		{
			if (id_round_FII == IntPtr.Zero)
				id_round_FII = JNIEnv.GetStaticMethodID (class_ref, "round", "(FII)F");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				return JNIEnv.CallStaticFloatMethod  (class_ref, id_round_FII, __args);
			} finally {
			}
		}

	}
}
