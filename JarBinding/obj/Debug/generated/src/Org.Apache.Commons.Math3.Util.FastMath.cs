using System;
using System.Collections.Generic;
using Android.Runtime;

namespace Org.Apache.Commons.Math3.Util {

	// Metadata.xml XPath class reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']"
	[global::Android.Runtime.Register ("org/apache/commons/math3/util/FastMath", DoNotGenerateAcw=true)]
	public partial class FastMath : global::Java.Lang.Object {


		// Metadata.xml XPath field reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/field[@name='E']"
		[Register ("E")]
		public const double E = (double) 2.718281828459045;

		// Metadata.xml XPath field reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/field[@name='PI']"
		[Register ("PI")]
		public const double Pi = (double) 3.141592653589793;
		// Metadata.xml XPath class reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath.CodyWaite']"
		[global::Android.Runtime.Register ("org/apache/commons/math3/util/FastMath$CodyWaite", DoNotGenerateAcw=true)]
		public partial class CodyWaite : global::Java.Lang.Object {

			protected CodyWaite (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		}

		// Metadata.xml XPath class reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath.ExpFracTable']"
		[global::Android.Runtime.Register ("org/apache/commons/math3/util/FastMath$ExpFracTable", DoNotGenerateAcw=true)]
		public partial class ExpFracTable : global::Java.Lang.Object {

			protected ExpFracTable (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		}

		// Metadata.xml XPath class reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath.ExpIntTable']"
		[global::Android.Runtime.Register ("org/apache/commons/math3/util/FastMath$ExpIntTable", DoNotGenerateAcw=true)]
		public partial class ExpIntTable : global::Java.Lang.Object {

			protected ExpIntTable (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		}

		// Metadata.xml XPath class reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath.lnMant']"
		[global::Android.Runtime.Register ("org/apache/commons/math3/util/FastMath$lnMant", DoNotGenerateAcw=true)]
		public partial class LnMant : global::Java.Lang.Object {

			protected LnMant (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		}

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("org/apache/commons/math3/util/FastMath", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (FastMath); }
		}

		protected FastMath (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_IEEEremainder_DD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='IEEEremainder' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='double']]"
		[Register ("IEEEremainder", "(DD)D", "")]
		public static unsafe double IEEEremainder (double p0, double p1)
		{
			if (id_IEEEremainder_DD == IntPtr.Zero)
				id_IEEEremainder_DD = JNIEnv.GetStaticMethodID (class_ref, "IEEEremainder", "(DD)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_IEEEremainder_DD, __args);
			} finally {
			}
		}

		static IntPtr id_abs_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='abs' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("abs", "(D)D", "")]
		public static unsafe double Abs (double p0)
		{
			if (id_abs_D == IntPtr.Zero)
				id_abs_D = JNIEnv.GetStaticMethodID (class_ref, "abs", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_abs_D, __args);
			} finally {
			}
		}

		static IntPtr id_abs_F;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='abs' and count(parameter)=1 and parameter[1][@type='float']]"
		[Register ("abs", "(F)F", "")]
		public static unsafe float Abs (float p0)
		{
			if (id_abs_F == IntPtr.Zero)
				id_abs_F = JNIEnv.GetStaticMethodID (class_ref, "abs", "(F)F");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticFloatMethod  (class_ref, id_abs_F, __args);
			} finally {
			}
		}

		static IntPtr id_abs_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='abs' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("abs", "(I)I", "")]
		public static unsafe int Abs (int p0)
		{
			if (id_abs_I == IntPtr.Zero)
				id_abs_I = JNIEnv.GetStaticMethodID (class_ref, "abs", "(I)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_abs_I, __args);
			} finally {
			}
		}

		static IntPtr id_abs_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='abs' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("abs", "(J)J", "")]
		public static unsafe long Abs (long p0)
		{
			if (id_abs_J == IntPtr.Zero)
				id_abs_J = JNIEnv.GetStaticMethodID (class_ref, "abs", "(J)J");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_abs_J, __args);
			} finally {
			}
		}

		static IntPtr id_acos_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='acos' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("acos", "(D)D", "")]
		public static unsafe double Acos (double p0)
		{
			if (id_acos_D == IntPtr.Zero)
				id_acos_D = JNIEnv.GetStaticMethodID (class_ref, "acos", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_acos_D, __args);
			} finally {
			}
		}

		static IntPtr id_acosh_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='acosh' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("acosh", "(D)D", "")]
		public static unsafe double Acosh (double p0)
		{
			if (id_acosh_D == IntPtr.Zero)
				id_acosh_D = JNIEnv.GetStaticMethodID (class_ref, "acosh", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_acosh_D, __args);
			} finally {
			}
		}

		static IntPtr id_addExact_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='addExact' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
		[Register ("addExact", "(II)I", "")]
		public static unsafe int AddExact (int p0, int p1)
		{
			if (id_addExact_II == IntPtr.Zero)
				id_addExact_II = JNIEnv.GetStaticMethodID (class_ref, "addExact", "(II)I");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_addExact_II, __args);
			} finally {
			}
		}

		static IntPtr id_addExact_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='addExact' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register ("addExact", "(JJ)J", "")]
		public static unsafe long AddExact (long p0, long p1)
		{
			if (id_addExact_JJ == IntPtr.Zero)
				id_addExact_JJ = JNIEnv.GetStaticMethodID (class_ref, "addExact", "(JJ)J");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_addExact_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_asin_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='asin' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("asin", "(D)D", "")]
		public static unsafe double Asin (double p0)
		{
			if (id_asin_D == IntPtr.Zero)
				id_asin_D = JNIEnv.GetStaticMethodID (class_ref, "asin", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_asin_D, __args);
			} finally {
			}
		}

		static IntPtr id_asinh_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='asinh' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("asinh", "(D)D", "")]
		public static unsafe double Asinh (double p0)
		{
			if (id_asinh_D == IntPtr.Zero)
				id_asinh_D = JNIEnv.GetStaticMethodID (class_ref, "asinh", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_asinh_D, __args);
			} finally {
			}
		}

		static IntPtr id_atan2_DD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='atan2' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='double']]"
		[Register ("atan2", "(DD)D", "")]
		public static unsafe double Atan2 (double p0, double p1)
		{
			if (id_atan2_DD == IntPtr.Zero)
				id_atan2_DD = JNIEnv.GetStaticMethodID (class_ref, "atan2", "(DD)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_atan2_DD, __args);
			} finally {
			}
		}

		static IntPtr id_atan_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='atan' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("atan", "(D)D", "")]
		public static unsafe double Atan (double p0)
		{
			if (id_atan_D == IntPtr.Zero)
				id_atan_D = JNIEnv.GetStaticMethodID (class_ref, "atan", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_atan_D, __args);
			} finally {
			}
		}

		static IntPtr id_atanh_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='atanh' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("atanh", "(D)D", "")]
		public static unsafe double Atanh (double p0)
		{
			if (id_atanh_D == IntPtr.Zero)
				id_atanh_D = JNIEnv.GetStaticMethodID (class_ref, "atanh", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_atanh_D, __args);
			} finally {
			}
		}

		static IntPtr id_cbrt_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='cbrt' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("cbrt", "(D)D", "")]
		public static unsafe double Cbrt (double p0)
		{
			if (id_cbrt_D == IntPtr.Zero)
				id_cbrt_D = JNIEnv.GetStaticMethodID (class_ref, "cbrt", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_cbrt_D, __args);
			} finally {
			}
		}

		static IntPtr id_ceil_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='ceil' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("ceil", "(D)D", "")]
		public static unsafe double Ceil (double p0)
		{
			if (id_ceil_D == IntPtr.Zero)
				id_ceil_D = JNIEnv.GetStaticMethodID (class_ref, "ceil", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_ceil_D, __args);
			} finally {
			}
		}

		static IntPtr id_copySign_DD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='copySign' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='double']]"
		[Register ("copySign", "(DD)D", "")]
		public static unsafe double CopySign (double p0, double p1)
		{
			if (id_copySign_DD == IntPtr.Zero)
				id_copySign_DD = JNIEnv.GetStaticMethodID (class_ref, "copySign", "(DD)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_copySign_DD, __args);
			} finally {
			}
		}

		static IntPtr id_copySign_FF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='copySign' and count(parameter)=2 and parameter[1][@type='float'] and parameter[2][@type='float']]"
		[Register ("copySign", "(FF)F", "")]
		public static unsafe float CopySign (float p0, float p1)
		{
			if (id_copySign_FF == IntPtr.Zero)
				id_copySign_FF = JNIEnv.GetStaticMethodID (class_ref, "copySign", "(FF)F");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticFloatMethod  (class_ref, id_copySign_FF, __args);
			} finally {
			}
		}

		static IntPtr id_cos_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='cos' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("cos", "(D)D", "")]
		public static unsafe double Cos (double p0)
		{
			if (id_cos_D == IntPtr.Zero)
				id_cos_D = JNIEnv.GetStaticMethodID (class_ref, "cos", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_cos_D, __args);
			} finally {
			}
		}

		static IntPtr id_cosh_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='cosh' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("cosh", "(D)D", "")]
		public static unsafe double Cosh (double p0)
		{
			if (id_cosh_D == IntPtr.Zero)
				id_cosh_D = JNIEnv.GetStaticMethodID (class_ref, "cosh", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_cosh_D, __args);
			} finally {
			}
		}

		static IntPtr id_decrementExact_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='decrementExact' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("decrementExact", "(I)I", "")]
		public static unsafe int DecrementExact (int p0)
		{
			if (id_decrementExact_I == IntPtr.Zero)
				id_decrementExact_I = JNIEnv.GetStaticMethodID (class_ref, "decrementExact", "(I)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_decrementExact_I, __args);
			} finally {
			}
		}

		static IntPtr id_decrementExact_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='decrementExact' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("decrementExact", "(J)J", "")]
		public static unsafe long DecrementExact (long p0)
		{
			if (id_decrementExact_J == IntPtr.Zero)
				id_decrementExact_J = JNIEnv.GetStaticMethodID (class_ref, "decrementExact", "(J)J");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_decrementExact_J, __args);
			} finally {
			}
		}

		static IntPtr id_exp_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='exp' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("exp", "(D)D", "")]
		public static unsafe double Exp (double p0)
		{
			if (id_exp_D == IntPtr.Zero)
				id_exp_D = JNIEnv.GetStaticMethodID (class_ref, "exp", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_exp_D, __args);
			} finally {
			}
		}

		static IntPtr id_expm1_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='expm1' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("expm1", "(D)D", "")]
		public static unsafe double Expm1 (double p0)
		{
			if (id_expm1_D == IntPtr.Zero)
				id_expm1_D = JNIEnv.GetStaticMethodID (class_ref, "expm1", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_expm1_D, __args);
			} finally {
			}
		}

		static IntPtr id_floor_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='floor' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("floor", "(D)D", "")]
		public static unsafe double Floor (double p0)
		{
			if (id_floor_D == IntPtr.Zero)
				id_floor_D = JNIEnv.GetStaticMethodID (class_ref, "floor", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_floor_D, __args);
			} finally {
			}
		}

		static IntPtr id_floorDiv_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='floorDiv' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
		[Register ("floorDiv", "(II)I", "")]
		public static unsafe int FloorDiv (int p0, int p1)
		{
			if (id_floorDiv_II == IntPtr.Zero)
				id_floorDiv_II = JNIEnv.GetStaticMethodID (class_ref, "floorDiv", "(II)I");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_floorDiv_II, __args);
			} finally {
			}
		}

		static IntPtr id_floorDiv_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='floorDiv' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register ("floorDiv", "(JJ)J", "")]
		public static unsafe long FloorDiv (long p0, long p1)
		{
			if (id_floorDiv_JJ == IntPtr.Zero)
				id_floorDiv_JJ = JNIEnv.GetStaticMethodID (class_ref, "floorDiv", "(JJ)J");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_floorDiv_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_floorMod_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='floorMod' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
		[Register ("floorMod", "(II)I", "")]
		public static unsafe int FloorMod (int p0, int p1)
		{
			if (id_floorMod_II == IntPtr.Zero)
				id_floorMod_II = JNIEnv.GetStaticMethodID (class_ref, "floorMod", "(II)I");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_floorMod_II, __args);
			} finally {
			}
		}

		static IntPtr id_floorMod_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='floorMod' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register ("floorMod", "(JJ)J", "")]
		public static unsafe long FloorMod (long p0, long p1)
		{
			if (id_floorMod_JJ == IntPtr.Zero)
				id_floorMod_JJ = JNIEnv.GetStaticMethodID (class_ref, "floorMod", "(JJ)J");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_floorMod_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_getExponent_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='getExponent' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("getExponent", "(D)I", "")]
		public static unsafe int GetExponent (double p0)
		{
			if (id_getExponent_D == IntPtr.Zero)
				id_getExponent_D = JNIEnv.GetStaticMethodID (class_ref, "getExponent", "(D)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_getExponent_D, __args);
			} finally {
			}
		}

		static IntPtr id_getExponent_F;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='getExponent' and count(parameter)=1 and parameter[1][@type='float']]"
		[Register ("getExponent", "(F)I", "")]
		public static unsafe int GetExponent (float p0)
		{
			if (id_getExponent_F == IntPtr.Zero)
				id_getExponent_F = JNIEnv.GetStaticMethodID (class_ref, "getExponent", "(F)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_getExponent_F, __args);
			} finally {
			}
		}

		static IntPtr id_hypot_DD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='hypot' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='double']]"
		[Register ("hypot", "(DD)D", "")]
		public static unsafe double Hypot (double p0, double p1)
		{
			if (id_hypot_DD == IntPtr.Zero)
				id_hypot_DD = JNIEnv.GetStaticMethodID (class_ref, "hypot", "(DD)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_hypot_DD, __args);
			} finally {
			}
		}

		static IntPtr id_incrementExact_I;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='incrementExact' and count(parameter)=1 and parameter[1][@type='int']]"
		[Register ("incrementExact", "(I)I", "")]
		public static unsafe int IncrementExact (int p0)
		{
			if (id_incrementExact_I == IntPtr.Zero)
				id_incrementExact_I = JNIEnv.GetStaticMethodID (class_ref, "incrementExact", "(I)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_incrementExact_I, __args);
			} finally {
			}
		}

		static IntPtr id_incrementExact_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='incrementExact' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("incrementExact", "(J)J", "")]
		public static unsafe long IncrementExact (long p0)
		{
			if (id_incrementExact_J == IntPtr.Zero)
				id_incrementExact_J = JNIEnv.GetStaticMethodID (class_ref, "incrementExact", "(J)J");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_incrementExact_J, __args);
			} finally {
			}
		}

		static IntPtr id_log10_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='log10' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("log10", "(D)D", "")]
		public static unsafe double Log10 (double p0)
		{
			if (id_log10_D == IntPtr.Zero)
				id_log10_D = JNIEnv.GetStaticMethodID (class_ref, "log10", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_log10_D, __args);
			} finally {
			}
		}

		static IntPtr id_log1p_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='log1p' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("log1p", "(D)D", "")]
		public static unsafe double Log1p (double p0)
		{
			if (id_log1p_D == IntPtr.Zero)
				id_log1p_D = JNIEnv.GetStaticMethodID (class_ref, "log1p", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_log1p_D, __args);
			} finally {
			}
		}

		static IntPtr id_log_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='log' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("log", "(D)D", "")]
		public static unsafe double Log (double p0)
		{
			if (id_log_D == IntPtr.Zero)
				id_log_D = JNIEnv.GetStaticMethodID (class_ref, "log", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_log_D, __args);
			} finally {
			}
		}

		static IntPtr id_log_DD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='log' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='double']]"
		[Register ("log", "(DD)D", "")]
		public static unsafe double Log (double p0, double p1)
		{
			if (id_log_DD == IntPtr.Zero)
				id_log_DD = JNIEnv.GetStaticMethodID (class_ref, "log", "(DD)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_log_DD, __args);
			} finally {
			}
		}

		static IntPtr id_main_arrayLjava_lang_String_;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='main' and count(parameter)=1 and parameter[1][@type='java.lang.String[]']]"
		[Register ("main", "([Ljava/lang/String;)V", "")]
		public static unsafe void Main (string[] p0)
		{
			if (id_main_arrayLjava_lang_String_ == IntPtr.Zero)
				id_main_arrayLjava_lang_String_ = JNIEnv.GetStaticMethodID (class_ref, "main", "([Ljava/lang/String;)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (native_p0);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_main_arrayLjava_lang_String_, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_max_DD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='max' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='double']]"
		[Register ("max", "(DD)D", "")]
		public static unsafe double Max (double p0, double p1)
		{
			if (id_max_DD == IntPtr.Zero)
				id_max_DD = JNIEnv.GetStaticMethodID (class_ref, "max", "(DD)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_max_DD, __args);
			} finally {
			}
		}

		static IntPtr id_max_FF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='max' and count(parameter)=2 and parameter[1][@type='float'] and parameter[2][@type='float']]"
		[Register ("max", "(FF)F", "")]
		public static unsafe float Max (float p0, float p1)
		{
			if (id_max_FF == IntPtr.Zero)
				id_max_FF = JNIEnv.GetStaticMethodID (class_ref, "max", "(FF)F");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticFloatMethod  (class_ref, id_max_FF, __args);
			} finally {
			}
		}

		static IntPtr id_max_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='max' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
		[Register ("max", "(II)I", "")]
		public static unsafe int Max (int p0, int p1)
		{
			if (id_max_II == IntPtr.Zero)
				id_max_II = JNIEnv.GetStaticMethodID (class_ref, "max", "(II)I");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_max_II, __args);
			} finally {
			}
		}

		static IntPtr id_max_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='max' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register ("max", "(JJ)J", "")]
		public static unsafe long Max (long p0, long p1)
		{
			if (id_max_JJ == IntPtr.Zero)
				id_max_JJ = JNIEnv.GetStaticMethodID (class_ref, "max", "(JJ)J");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_max_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_min_DD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='min' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='double']]"
		[Register ("min", "(DD)D", "")]
		public static unsafe double Min (double p0, double p1)
		{
			if (id_min_DD == IntPtr.Zero)
				id_min_DD = JNIEnv.GetStaticMethodID (class_ref, "min", "(DD)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_min_DD, __args);
			} finally {
			}
		}

		static IntPtr id_min_FF;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='min' and count(parameter)=2 and parameter[1][@type='float'] and parameter[2][@type='float']]"
		[Register ("min", "(FF)F", "")]
		public static unsafe float Min (float p0, float p1)
		{
			if (id_min_FF == IntPtr.Zero)
				id_min_FF = JNIEnv.GetStaticMethodID (class_ref, "min", "(FF)F");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticFloatMethod  (class_ref, id_min_FF, __args);
			} finally {
			}
		}

		static IntPtr id_min_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='min' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
		[Register ("min", "(II)I", "")]
		public static unsafe int Min (int p0, int p1)
		{
			if (id_min_II == IntPtr.Zero)
				id_min_II = JNIEnv.GetStaticMethodID (class_ref, "min", "(II)I");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_min_II, __args);
			} finally {
			}
		}

		static IntPtr id_min_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='min' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register ("min", "(JJ)J", "")]
		public static unsafe long Min (long p0, long p1)
		{
			if (id_min_JJ == IntPtr.Zero)
				id_min_JJ = JNIEnv.GetStaticMethodID (class_ref, "min", "(JJ)J");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_min_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_multiplyExact_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='multiplyExact' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
		[Register ("multiplyExact", "(II)I", "")]
		public static unsafe int MultiplyExact (int p0, int p1)
		{
			if (id_multiplyExact_II == IntPtr.Zero)
				id_multiplyExact_II = JNIEnv.GetStaticMethodID (class_ref, "multiplyExact", "(II)I");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_multiplyExact_II, __args);
			} finally {
			}
		}

		static IntPtr id_multiplyExact_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='multiplyExact' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register ("multiplyExact", "(JJ)J", "")]
		public static unsafe long MultiplyExact (long p0, long p1)
		{
			if (id_multiplyExact_JJ == IntPtr.Zero)
				id_multiplyExact_JJ = JNIEnv.GetStaticMethodID (class_ref, "multiplyExact", "(JJ)J");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_multiplyExact_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_nextAfter_DD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='nextAfter' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='double']]"
		[Register ("nextAfter", "(DD)D", "")]
		public static unsafe double NextAfter (double p0, double p1)
		{
			if (id_nextAfter_DD == IntPtr.Zero)
				id_nextAfter_DD = JNIEnv.GetStaticMethodID (class_ref, "nextAfter", "(DD)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_nextAfter_DD, __args);
			} finally {
			}
		}

		static IntPtr id_nextAfter_FD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='nextAfter' and count(parameter)=2 and parameter[1][@type='float'] and parameter[2][@type='double']]"
		[Register ("nextAfter", "(FD)F", "")]
		public static unsafe float NextAfter (float p0, double p1)
		{
			if (id_nextAfter_FD == IntPtr.Zero)
				id_nextAfter_FD = JNIEnv.GetStaticMethodID (class_ref, "nextAfter", "(FD)F");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticFloatMethod  (class_ref, id_nextAfter_FD, __args);
			} finally {
			}
		}

		static IntPtr id_nextDown_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='nextDown' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("nextDown", "(D)D", "")]
		public static unsafe double NextDown (double p0)
		{
			if (id_nextDown_D == IntPtr.Zero)
				id_nextDown_D = JNIEnv.GetStaticMethodID (class_ref, "nextDown", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_nextDown_D, __args);
			} finally {
			}
		}

		static IntPtr id_nextDown_F;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='nextDown' and count(parameter)=1 and parameter[1][@type='float']]"
		[Register ("nextDown", "(F)F", "")]
		public static unsafe float NextDown (float p0)
		{
			if (id_nextDown_F == IntPtr.Zero)
				id_nextDown_F = JNIEnv.GetStaticMethodID (class_ref, "nextDown", "(F)F");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticFloatMethod  (class_ref, id_nextDown_F, __args);
			} finally {
			}
		}

		static IntPtr id_nextUp_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='nextUp' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("nextUp", "(D)D", "")]
		public static unsafe double NextUp (double p0)
		{
			if (id_nextUp_D == IntPtr.Zero)
				id_nextUp_D = JNIEnv.GetStaticMethodID (class_ref, "nextUp", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_nextUp_D, __args);
			} finally {
			}
		}

		static IntPtr id_nextUp_F;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='nextUp' and count(parameter)=1 and parameter[1][@type='float']]"
		[Register ("nextUp", "(F)F", "")]
		public static unsafe float NextUp (float p0)
		{
			if (id_nextUp_F == IntPtr.Zero)
				id_nextUp_F = JNIEnv.GetStaticMethodID (class_ref, "nextUp", "(F)F");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticFloatMethod  (class_ref, id_nextUp_F, __args);
			} finally {
			}
		}

		static IntPtr id_pow_DD;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='pow' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='double']]"
		[Register ("pow", "(DD)D", "")]
		public static unsafe double Pow (double p0, double p1)
		{
			if (id_pow_DD == IntPtr.Zero)
				id_pow_DD = JNIEnv.GetStaticMethodID (class_ref, "pow", "(DD)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_pow_DD, __args);
			} finally {
			}
		}

		static IntPtr id_pow_DI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='pow' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='int']]"
		[Register ("pow", "(DI)D", "")]
		public static unsafe double Pow (double p0, int p1)
		{
			if (id_pow_DI == IntPtr.Zero)
				id_pow_DI = JNIEnv.GetStaticMethodID (class_ref, "pow", "(DI)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_pow_DI, __args);
			} finally {
			}
		}

		static IntPtr id_random;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='random' and count(parameter)=0]"
		[Register ("random", "()D", "")]
		public static unsafe double Random ()
		{
			if (id_random == IntPtr.Zero)
				id_random = JNIEnv.GetStaticMethodID (class_ref, "random", "()D");
			try {
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_random);
			} finally {
			}
		}

		static IntPtr id_rint_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='rint' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("rint", "(D)D", "")]
		public static unsafe double Rint (double p0)
		{
			if (id_rint_D == IntPtr.Zero)
				id_rint_D = JNIEnv.GetStaticMethodID (class_ref, "rint", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_rint_D, __args);
			} finally {
			}
		}

		static IntPtr id_round_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='round' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("round", "(D)J", "")]
		public static unsafe long Round (double p0)
		{
			if (id_round_D == IntPtr.Zero)
				id_round_D = JNIEnv.GetStaticMethodID (class_ref, "round", "(D)J");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_round_D, __args);
			} finally {
			}
		}

		static IntPtr id_round_F;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='round' and count(parameter)=1 and parameter[1][@type='float']]"
		[Register ("round", "(F)I", "")]
		public static unsafe int Round (float p0)
		{
			if (id_round_F == IntPtr.Zero)
				id_round_F = JNIEnv.GetStaticMethodID (class_ref, "round", "(F)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_round_F, __args);
			} finally {
			}
		}

		static IntPtr id_scalb_DI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='scalb' and count(parameter)=2 and parameter[1][@type='double'] and parameter[2][@type='int']]"
		[Register ("scalb", "(DI)D", "")]
		public static unsafe double Scalb (double p0, int p1)
		{
			if (id_scalb_DI == IntPtr.Zero)
				id_scalb_DI = JNIEnv.GetStaticMethodID (class_ref, "scalb", "(DI)D");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_scalb_DI, __args);
			} finally {
			}
		}

		static IntPtr id_scalb_FI;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='scalb' and count(parameter)=2 and parameter[1][@type='float'] and parameter[2][@type='int']]"
		[Register ("scalb", "(FI)F", "")]
		public static unsafe float Scalb (float p0, int p1)
		{
			if (id_scalb_FI == IntPtr.Zero)
				id_scalb_FI = JNIEnv.GetStaticMethodID (class_ref, "scalb", "(FI)F");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticFloatMethod  (class_ref, id_scalb_FI, __args);
			} finally {
			}
		}

		static IntPtr id_signum_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='signum' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("signum", "(D)D", "")]
		public static unsafe double Signum (double p0)
		{
			if (id_signum_D == IntPtr.Zero)
				id_signum_D = JNIEnv.GetStaticMethodID (class_ref, "signum", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_signum_D, __args);
			} finally {
			}
		}

		static IntPtr id_signum_F;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='signum' and count(parameter)=1 and parameter[1][@type='float']]"
		[Register ("signum", "(F)F", "")]
		public static unsafe float Signum (float p0)
		{
			if (id_signum_F == IntPtr.Zero)
				id_signum_F = JNIEnv.GetStaticMethodID (class_ref, "signum", "(F)F");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticFloatMethod  (class_ref, id_signum_F, __args);
			} finally {
			}
		}

		static IntPtr id_sin_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='sin' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("sin", "(D)D", "")]
		public static unsafe double Sin (double p0)
		{
			if (id_sin_D == IntPtr.Zero)
				id_sin_D = JNIEnv.GetStaticMethodID (class_ref, "sin", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_sin_D, __args);
			} finally {
			}
		}

		static IntPtr id_sinh_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='sinh' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("sinh", "(D)D", "")]
		public static unsafe double Sinh (double p0)
		{
			if (id_sinh_D == IntPtr.Zero)
				id_sinh_D = JNIEnv.GetStaticMethodID (class_ref, "sinh", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_sinh_D, __args);
			} finally {
			}
		}

		static IntPtr id_sqrt_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='sqrt' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("sqrt", "(D)D", "")]
		public static unsafe double Sqrt (double p0)
		{
			if (id_sqrt_D == IntPtr.Zero)
				id_sqrt_D = JNIEnv.GetStaticMethodID (class_ref, "sqrt", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_sqrt_D, __args);
			} finally {
			}
		}

		static IntPtr id_subtractExact_II;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='subtractExact' and count(parameter)=2 and parameter[1][@type='int'] and parameter[2][@type='int']]"
		[Register ("subtractExact", "(II)I", "")]
		public static unsafe int SubtractExact (int p0, int p1)
		{
			if (id_subtractExact_II == IntPtr.Zero)
				id_subtractExact_II = JNIEnv.GetStaticMethodID (class_ref, "subtractExact", "(II)I");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_subtractExact_II, __args);
			} finally {
			}
		}

		static IntPtr id_subtractExact_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='subtractExact' and count(parameter)=2 and parameter[1][@type='long'] and parameter[2][@type='long']]"
		[Register ("subtractExact", "(JJ)J", "")]
		public static unsafe long SubtractExact (long p0, long p1)
		{
			if (id_subtractExact_JJ == IntPtr.Zero)
				id_subtractExact_JJ = JNIEnv.GetStaticMethodID (class_ref, "subtractExact", "(JJ)J");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				return JNIEnv.CallStaticLongMethod  (class_ref, id_subtractExact_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_tan_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='tan' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("tan", "(D)D", "")]
		public static unsafe double Tan (double p0)
		{
			if (id_tan_D == IntPtr.Zero)
				id_tan_D = JNIEnv.GetStaticMethodID (class_ref, "tan", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_tan_D, __args);
			} finally {
			}
		}

		static IntPtr id_tanh_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='tanh' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("tanh", "(D)D", "")]
		public static unsafe double Tanh (double p0)
		{
			if (id_tanh_D == IntPtr.Zero)
				id_tanh_D = JNIEnv.GetStaticMethodID (class_ref, "tanh", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_tanh_D, __args);
			} finally {
			}
		}

		static IntPtr id_toDegrees_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='toDegrees' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("toDegrees", "(D)D", "")]
		public static unsafe double ToDegrees (double p0)
		{
			if (id_toDegrees_D == IntPtr.Zero)
				id_toDegrees_D = JNIEnv.GetStaticMethodID (class_ref, "toDegrees", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_toDegrees_D, __args);
			} finally {
			}
		}

		static IntPtr id_toIntExact_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='toIntExact' and count(parameter)=1 and parameter[1][@type='long']]"
		[Register ("toIntExact", "(J)I", "")]
		public static unsafe int ToIntExact (long p0)
		{
			if (id_toIntExact_J == IntPtr.Zero)
				id_toIntExact_J = JNIEnv.GetStaticMethodID (class_ref, "toIntExact", "(J)I");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticIntMethod  (class_ref, id_toIntExact_J, __args);
			} finally {
			}
		}

		static IntPtr id_toRadians_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='toRadians' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("toRadians", "(D)D", "")]
		public static unsafe double ToRadians (double p0)
		{
			if (id_toRadians_D == IntPtr.Zero)
				id_toRadians_D = JNIEnv.GetStaticMethodID (class_ref, "toRadians", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_toRadians_D, __args);
			} finally {
			}
		}

		static IntPtr id_ulp_D;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='ulp' and count(parameter)=1 and parameter[1][@type='double']]"
		[Register ("ulp", "(D)D", "")]
		public static unsafe double Ulp (double p0)
		{
			if (id_ulp_D == IntPtr.Zero)
				id_ulp_D = JNIEnv.GetStaticMethodID (class_ref, "ulp", "(D)D");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticDoubleMethod  (class_ref, id_ulp_D, __args);
			} finally {
			}
		}

		static IntPtr id_ulp_F;
		// Metadata.xml XPath method reference: path="/api/package[@name='org.apache.commons.math3.util']/class[@name='FastMath']/method[@name='ulp' and count(parameter)=1 and parameter[1][@type='float']]"
		[Register ("ulp", "(F)F", "")]
		public static unsafe float Ulp (float p0)
		{
			if (id_ulp_F == IntPtr.Zero)
				id_ulp_F = JNIEnv.GetStaticMethodID (class_ref, "ulp", "(F)F");
			try {
				JValue* __args = stackalloc JValue [1];
				__args [0] = new JValue (p0);
				return JNIEnv.CallStaticFloatMethod  (class_ref, id_ulp_F, __args);
			} finally {
			}
		}

	}
}
