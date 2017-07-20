using System;
using System.Collections.Generic;
using Android.Runtime;

namespace PL.Edu.Icm.Jlargearrays {

	// Metadata.xml XPath class reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']"
	[global::Android.Runtime.Register ("pl/edu/icm/jlargearrays/LargeArrayUtils", DoNotGenerateAcw=true)]
	public partial class LargeArrayUtils : global::Java.Lang.Object {

		internal static IntPtr java_class_handle;
		internal static IntPtr class_ref {
			get {
				return JNIEnv.FindClass ("pl/edu/icm/jlargearrays/LargeArrayUtils", ref java_class_handle);
			}
		}

		protected override IntPtr ThresholdClass {
			get { return class_ref; }
		}

		protected override global::System.Type ThresholdType {
			get { return typeof (LargeArrayUtils); }
		}

		protected LargeArrayUtils (IntPtr javaReference, JniHandleOwnership transfer) : base (javaReference, transfer) {}

		static IntPtr id_arraycopy_arrayZILpl_edu_icm_jlargearrays_LogicLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='boolean[]'] and parameter[2][@type='int'] and parameter[3][@type='pl.edu.icm.jlargearrays.LogicLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "([ZILpl/edu/icm/jlargearrays/LogicLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (bool[] p0, int p1, global::PL.Edu.Icm.Jlargearrays.LogicLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_arrayZILpl_edu_icm_jlargearrays_LogicLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_arrayZILpl_edu_icm_jlargearrays_LogicLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "([ZILpl/edu/icm/jlargearrays/LogicLargeArray;JJ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_arrayZILpl_edu_icm_jlargearrays_LogicLargeArray_JJ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_arraycopy_arrayBILpl_edu_icm_jlargearrays_ByteLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='byte[]'] and parameter[2][@type='int'] and parameter[3][@type='pl.edu.icm.jlargearrays.ByteLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "([BILpl/edu/icm/jlargearrays/ByteLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (byte[] p0, int p1, global::PL.Edu.Icm.Jlargearrays.ByteLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_arrayBILpl_edu_icm_jlargearrays_ByteLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_arrayBILpl_edu_icm_jlargearrays_ByteLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "([BILpl/edu/icm/jlargearrays/ByteLargeArray;JJ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_arrayBILpl_edu_icm_jlargearrays_ByteLargeArray_JJ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_arraycopy_arrayBILpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='byte[]'] and parameter[2][@type='int'] and parameter[3][@type='pl.edu.icm.jlargearrays.UnsignedByteLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "([BILpl/edu/icm/jlargearrays/UnsignedByteLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (byte[] p0, int p1, global::PL.Edu.Icm.Jlargearrays.UnsignedByteLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_arrayBILpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_arrayBILpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "([BILpl/edu/icm/jlargearrays/UnsignedByteLargeArray;JJ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_arrayBILpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JJ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_arraycopy_arrayDILpl_edu_icm_jlargearrays_ComplexDoubleLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='double[]'] and parameter[2][@type='int'] and parameter[3][@type='pl.edu.icm.jlargearrays.ComplexDoubleLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "([DILpl/edu/icm/jlargearrays/ComplexDoubleLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (double[] p0, int p1, global::PL.Edu.Icm.Jlargearrays.ComplexDoubleLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_arrayDILpl_edu_icm_jlargearrays_ComplexDoubleLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_arrayDILpl_edu_icm_jlargearrays_ComplexDoubleLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "([DILpl/edu/icm/jlargearrays/ComplexDoubleLargeArray;JJ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_arrayDILpl_edu_icm_jlargearrays_ComplexDoubleLargeArray_JJ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_arraycopy_arrayDILpl_edu_icm_jlargearrays_DoubleLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='double[]'] and parameter[2][@type='int'] and parameter[3][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "([DILpl/edu/icm/jlargearrays/DoubleLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (double[] p0, int p1, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_arrayDILpl_edu_icm_jlargearrays_DoubleLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_arrayDILpl_edu_icm_jlargearrays_DoubleLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "([DILpl/edu/icm/jlargearrays/DoubleLargeArray;JJ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_arrayDILpl_edu_icm_jlargearrays_DoubleLargeArray_JJ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_arraycopy_arrayFILpl_edu_icm_jlargearrays_ComplexFloatLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='float[]'] and parameter[2][@type='int'] and parameter[3][@type='pl.edu.icm.jlargearrays.ComplexFloatLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "([FILpl/edu/icm/jlargearrays/ComplexFloatLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (float[] p0, int p1, global::PL.Edu.Icm.Jlargearrays.ComplexFloatLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_arrayFILpl_edu_icm_jlargearrays_ComplexFloatLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_arrayFILpl_edu_icm_jlargearrays_ComplexFloatLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "([FILpl/edu/icm/jlargearrays/ComplexFloatLargeArray;JJ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_arrayFILpl_edu_icm_jlargearrays_ComplexFloatLargeArray_JJ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_arraycopy_arrayFILpl_edu_icm_jlargearrays_FloatLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='float[]'] and parameter[2][@type='int'] and parameter[3][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "([FILpl/edu/icm/jlargearrays/FloatLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (float[] p0, int p1, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_arrayFILpl_edu_icm_jlargearrays_FloatLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_arrayFILpl_edu_icm_jlargearrays_FloatLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "([FILpl/edu/icm/jlargearrays/FloatLargeArray;JJ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_arrayFILpl_edu_icm_jlargearrays_FloatLargeArray_JJ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_arraycopy_arrayIILpl_edu_icm_jlargearrays_IntLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='int[]'] and parameter[2][@type='int'] and parameter[3][@type='pl.edu.icm.jlargearrays.IntLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "([IILpl/edu/icm/jlargearrays/IntLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (int[] p0, int p1, global::PL.Edu.Icm.Jlargearrays.IntLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_arrayIILpl_edu_icm_jlargearrays_IntLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_arrayIILpl_edu_icm_jlargearrays_IntLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "([IILpl/edu/icm/jlargearrays/IntLargeArray;JJ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_arrayIILpl_edu_icm_jlargearrays_IntLargeArray_JJ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_arraycopy_Ljava_lang_Object_JLpl_edu_icm_jlargearrays_LargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='java.lang.Object'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.LargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "(Ljava/lang/Object;JLpl/edu/icm/jlargearrays/LargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::Java.Lang.Object p0, long p1, global::PL.Edu.Icm.Jlargearrays.LargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_Ljava_lang_Object_JLpl_edu_icm_jlargearrays_LargeArray_JJ == IntPtr.Zero)
				id_arraycopy_Ljava_lang_Object_JLpl_edu_icm_jlargearrays_LargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "(Ljava/lang/Object;JLpl/edu/icm/jlargearrays/LargeArray;JJ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_Ljava_lang_Object_JLpl_edu_icm_jlargearrays_LargeArray_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_arraycopy_arrayLjava_lang_Object_ILpl_edu_icm_jlargearrays_ObjectLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='java.lang.Object[]'] and parameter[2][@type='int'] and parameter[3][@type='pl.edu.icm.jlargearrays.ObjectLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "([Ljava/lang/Object;ILpl/edu/icm/jlargearrays/ObjectLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::Java.Lang.Object[] p0, int p1, global::PL.Edu.Icm.Jlargearrays.ObjectLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_arrayLjava_lang_Object_ILpl_edu_icm_jlargearrays_ObjectLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_arrayLjava_lang_Object_ILpl_edu_icm_jlargearrays_ObjectLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "([Ljava/lang/Object;ILpl/edu/icm/jlargearrays/ObjectLargeArray;JJ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_arrayLjava_lang_Object_ILpl_edu_icm_jlargearrays_ObjectLargeArray_JJ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_arraycopy_arrayLjava_lang_String_ILpl_edu_icm_jlargearrays_StringLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='java.lang.String[]'] and parameter[2][@type='int'] and parameter[3][@type='pl.edu.icm.jlargearrays.StringLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "([Ljava/lang/String;ILpl/edu/icm/jlargearrays/StringLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (string[] p0, int p1, global::PL.Edu.Icm.Jlargearrays.StringLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_arrayLjava_lang_String_ILpl_edu_icm_jlargearrays_StringLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_arrayLjava_lang_String_ILpl_edu_icm_jlargearrays_StringLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "([Ljava/lang/String;ILpl/edu/icm/jlargearrays/StringLargeArray;JJ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_arrayLjava_lang_String_ILpl_edu_icm_jlargearrays_StringLargeArray_JJ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_arraycopy_arrayJILpl_edu_icm_jlargearrays_LongLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='long[]'] and parameter[2][@type='int'] and parameter[3][@type='pl.edu.icm.jlargearrays.LongLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "([JILpl/edu/icm/jlargearrays/LongLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (long[] p0, int p1, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_arrayJILpl_edu_icm_jlargearrays_LongLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_arrayJILpl_edu_icm_jlargearrays_LongLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "([JILpl/edu/icm/jlargearrays/LongLargeArray;JJ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_arrayJILpl_edu_icm_jlargearrays_LongLargeArray_JJ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_arraycopy_Lpl_edu_icm_jlargearrays_ByteLargeArray_JLpl_edu_icm_jlargearrays_ByteLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='pl.edu.icm.jlargearrays.ByteLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.ByteLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "(Lpl/edu/icm/jlargearrays/ByteLargeArray;JLpl/edu/icm/jlargearrays/ByteLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::PL.Edu.Icm.Jlargearrays.ByteLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.ByteLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_Lpl_edu_icm_jlargearrays_ByteLargeArray_JLpl_edu_icm_jlargearrays_ByteLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_Lpl_edu_icm_jlargearrays_ByteLargeArray_JLpl_edu_icm_jlargearrays_ByteLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "(Lpl/edu/icm/jlargearrays/ByteLargeArray;JLpl/edu/icm/jlargearrays/ByteLargeArray;JJ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_Lpl_edu_icm_jlargearrays_ByteLargeArray_JLpl_edu_icm_jlargearrays_ByteLargeArray_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_arraycopy_Lpl_edu_icm_jlargearrays_ComplexDoubleLargeArray_JLpl_edu_icm_jlargearrays_ComplexDoubleLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='pl.edu.icm.jlargearrays.ComplexDoubleLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.ComplexDoubleLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "(Lpl/edu/icm/jlargearrays/ComplexDoubleLargeArray;JLpl/edu/icm/jlargearrays/ComplexDoubleLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::PL.Edu.Icm.Jlargearrays.ComplexDoubleLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.ComplexDoubleLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_Lpl_edu_icm_jlargearrays_ComplexDoubleLargeArray_JLpl_edu_icm_jlargearrays_ComplexDoubleLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_Lpl_edu_icm_jlargearrays_ComplexDoubleLargeArray_JLpl_edu_icm_jlargearrays_ComplexDoubleLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "(Lpl/edu/icm/jlargearrays/ComplexDoubleLargeArray;JLpl/edu/icm/jlargearrays/ComplexDoubleLargeArray;JJ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_Lpl_edu_icm_jlargearrays_ComplexDoubleLargeArray_JLpl_edu_icm_jlargearrays_ComplexDoubleLargeArray_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_arraycopy_Lpl_edu_icm_jlargearrays_ComplexFloatLargeArray_JLpl_edu_icm_jlargearrays_ComplexFloatLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='pl.edu.icm.jlargearrays.ComplexFloatLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.ComplexFloatLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "(Lpl/edu/icm/jlargearrays/ComplexFloatLargeArray;JLpl/edu/icm/jlargearrays/ComplexFloatLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::PL.Edu.Icm.Jlargearrays.ComplexFloatLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.ComplexFloatLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_Lpl_edu_icm_jlargearrays_ComplexFloatLargeArray_JLpl_edu_icm_jlargearrays_ComplexFloatLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_Lpl_edu_icm_jlargearrays_ComplexFloatLargeArray_JLpl_edu_icm_jlargearrays_ComplexFloatLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "(Lpl/edu/icm/jlargearrays/ComplexFloatLargeArray;JLpl/edu/icm/jlargearrays/ComplexFloatLargeArray;JJ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_Lpl_edu_icm_jlargearrays_ComplexFloatLargeArray_JLpl_edu_icm_jlargearrays_ComplexFloatLargeArray_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_arraycopy_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.DoubleLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.DoubleLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "(Lpl/edu/icm/jlargearrays/DoubleLargeArray;JLpl/edu/icm/jlargearrays/DoubleLargeArray;JJ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_Lpl_edu_icm_jlargearrays_DoubleLargeArray_JLpl_edu_icm_jlargearrays_DoubleLargeArray_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_arraycopy_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.FloatLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.FloatLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "(Lpl/edu/icm/jlargearrays/FloatLargeArray;JLpl/edu/icm/jlargearrays/FloatLargeArray;JJ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_Lpl_edu_icm_jlargearrays_FloatLargeArray_JLpl_edu_icm_jlargearrays_FloatLargeArray_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_arraycopy_Lpl_edu_icm_jlargearrays_IntLargeArray_JLpl_edu_icm_jlargearrays_IntLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='pl.edu.icm.jlargearrays.IntLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.IntLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "(Lpl/edu/icm/jlargearrays/IntLargeArray;JLpl/edu/icm/jlargearrays/IntLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::PL.Edu.Icm.Jlargearrays.IntLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.IntLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_Lpl_edu_icm_jlargearrays_IntLargeArray_JLpl_edu_icm_jlargearrays_IntLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_Lpl_edu_icm_jlargearrays_IntLargeArray_JLpl_edu_icm_jlargearrays_IntLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "(Lpl/edu/icm/jlargearrays/IntLargeArray;JLpl/edu/icm/jlargearrays/IntLargeArray;JJ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_Lpl_edu_icm_jlargearrays_IntLargeArray_JLpl_edu_icm_jlargearrays_IntLargeArray_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_arraycopy_Lpl_edu_icm_jlargearrays_LargeArray_JLpl_edu_icm_jlargearrays_LargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='pl.edu.icm.jlargearrays.LargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.LargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "(Lpl/edu/icm/jlargearrays/LargeArray;JLpl/edu/icm/jlargearrays/LargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::PL.Edu.Icm.Jlargearrays.LargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.LargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_Lpl_edu_icm_jlargearrays_LargeArray_JLpl_edu_icm_jlargearrays_LargeArray_JJ == IntPtr.Zero)
				id_arraycopy_Lpl_edu_icm_jlargearrays_LargeArray_JLpl_edu_icm_jlargearrays_LargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "(Lpl/edu/icm/jlargearrays/LargeArray;JLpl/edu/icm/jlargearrays/LargeArray;JJ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_Lpl_edu_icm_jlargearrays_LargeArray_JLpl_edu_icm_jlargearrays_LargeArray_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_arraycopy_Lpl_edu_icm_jlargearrays_LogicLargeArray_JLpl_edu_icm_jlargearrays_LogicLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='pl.edu.icm.jlargearrays.LogicLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.LogicLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "(Lpl/edu/icm/jlargearrays/LogicLargeArray;JLpl/edu/icm/jlargearrays/LogicLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::PL.Edu.Icm.Jlargearrays.LogicLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.LogicLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_Lpl_edu_icm_jlargearrays_LogicLargeArray_JLpl_edu_icm_jlargearrays_LogicLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_Lpl_edu_icm_jlargearrays_LogicLargeArray_JLpl_edu_icm_jlargearrays_LogicLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "(Lpl/edu/icm/jlargearrays/LogicLargeArray;JLpl/edu/icm/jlargearrays/LogicLargeArray;JJ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_Lpl_edu_icm_jlargearrays_LogicLargeArray_JLpl_edu_icm_jlargearrays_LogicLargeArray_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_arraycopy_Lpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='pl.edu.icm.jlargearrays.LongLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.LongLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "(Lpl/edu/icm/jlargearrays/LongLargeArray;JLpl/edu/icm/jlargearrays/LongLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::PL.Edu.Icm.Jlargearrays.LongLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.LongLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_Lpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_Lpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "(Lpl/edu/icm/jlargearrays/LongLargeArray;JLpl/edu/icm/jlargearrays/LongLargeArray;JJ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_Lpl_edu_icm_jlargearrays_LongLargeArray_JLpl_edu_icm_jlargearrays_LongLargeArray_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_arraycopy_Lpl_edu_icm_jlargearrays_ObjectLargeArray_JLpl_edu_icm_jlargearrays_ObjectLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='pl.edu.icm.jlargearrays.ObjectLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.ObjectLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "(Lpl/edu/icm/jlargearrays/ObjectLargeArray;JLpl/edu/icm/jlargearrays/ObjectLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::PL.Edu.Icm.Jlargearrays.ObjectLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.ObjectLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_Lpl_edu_icm_jlargearrays_ObjectLargeArray_JLpl_edu_icm_jlargearrays_ObjectLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_Lpl_edu_icm_jlargearrays_ObjectLargeArray_JLpl_edu_icm_jlargearrays_ObjectLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "(Lpl/edu/icm/jlargearrays/ObjectLargeArray;JLpl/edu/icm/jlargearrays/ObjectLargeArray;JJ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_Lpl_edu_icm_jlargearrays_ObjectLargeArray_JLpl_edu_icm_jlargearrays_ObjectLargeArray_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_arraycopy_Lpl_edu_icm_jlargearrays_ShortLargeArray_JLpl_edu_icm_jlargearrays_ShortLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='pl.edu.icm.jlargearrays.ShortLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.ShortLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "(Lpl/edu/icm/jlargearrays/ShortLargeArray;JLpl/edu/icm/jlargearrays/ShortLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::PL.Edu.Icm.Jlargearrays.ShortLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.ShortLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_Lpl_edu_icm_jlargearrays_ShortLargeArray_JLpl_edu_icm_jlargearrays_ShortLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_Lpl_edu_icm_jlargearrays_ShortLargeArray_JLpl_edu_icm_jlargearrays_ShortLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "(Lpl/edu/icm/jlargearrays/ShortLargeArray;JLpl/edu/icm/jlargearrays/ShortLargeArray;JJ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_Lpl_edu_icm_jlargearrays_ShortLargeArray_JLpl_edu_icm_jlargearrays_ShortLargeArray_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_arraycopy_Lpl_edu_icm_jlargearrays_StringLargeArray_JLpl_edu_icm_jlargearrays_StringLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='pl.edu.icm.jlargearrays.StringLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.StringLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "(Lpl/edu/icm/jlargearrays/StringLargeArray;JLpl/edu/icm/jlargearrays/StringLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::PL.Edu.Icm.Jlargearrays.StringLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.StringLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_Lpl_edu_icm_jlargearrays_StringLargeArray_JLpl_edu_icm_jlargearrays_StringLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_Lpl_edu_icm_jlargearrays_StringLargeArray_JLpl_edu_icm_jlargearrays_StringLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "(Lpl/edu/icm/jlargearrays/StringLargeArray;JLpl/edu/icm/jlargearrays/StringLargeArray;JJ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_Lpl_edu_icm_jlargearrays_StringLargeArray_JLpl_edu_icm_jlargearrays_StringLargeArray_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_arraycopy_Lpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JLpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='pl.edu.icm.jlargearrays.UnsignedByteLargeArray'] and parameter[2][@type='long'] and parameter[3][@type='pl.edu.icm.jlargearrays.UnsignedByteLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "(Lpl/edu/icm/jlargearrays/UnsignedByteLargeArray;JLpl/edu/icm/jlargearrays/UnsignedByteLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (global::PL.Edu.Icm.Jlargearrays.UnsignedByteLargeArray p0, long p1, global::PL.Edu.Icm.Jlargearrays.UnsignedByteLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_Lpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JLpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_Lpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JLpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "(Lpl/edu/icm/jlargearrays/UnsignedByteLargeArray;JLpl/edu/icm/jlargearrays/UnsignedByteLargeArray;JJ)V");
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_Lpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JLpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JJ, __args);
			} finally {
			}
		}

		static IntPtr id_arraycopy_arraySILpl_edu_icm_jlargearrays_ShortLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='short[]'] and parameter[2][@type='int'] and parameter[3][@type='pl.edu.icm.jlargearrays.ShortLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "([SILpl/edu/icm/jlargearrays/ShortLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (short[] p0, int p1, global::PL.Edu.Icm.Jlargearrays.ShortLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_arraySILpl_edu_icm_jlargearrays_ShortLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_arraySILpl_edu_icm_jlargearrays_ShortLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "([SILpl/edu/icm/jlargearrays/ShortLargeArray;JJ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_arraySILpl_edu_icm_jlargearrays_ShortLargeArray_JJ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_arraycopy_arraySILpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JJ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='arraycopy' and count(parameter)=5 and parameter[1][@type='short[]'] and parameter[2][@type='int'] and parameter[3][@type='pl.edu.icm.jlargearrays.UnsignedByteLargeArray'] and parameter[4][@type='long'] and parameter[5][@type='long']]"
		[Register ("arraycopy", "([SILpl/edu/icm/jlargearrays/UnsignedByteLargeArray;JJ)V", "")]
		public static unsafe void Arraycopy (short[] p0, int p1, global::PL.Edu.Icm.Jlargearrays.UnsignedByteLargeArray p2, long p3, long p4)
		{
			if (id_arraycopy_arraySILpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JJ == IntPtr.Zero)
				id_arraycopy_arraySILpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JJ = JNIEnv.GetStaticMethodID (class_ref, "arraycopy", "([SILpl/edu/icm/jlargearrays/UnsignedByteLargeArray;JJ)V");
			IntPtr native_p0 = JNIEnv.NewArray (p0);
			try {
				JValue* __args = stackalloc JValue [5];
				__args [0] = new JValue (native_p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				__args [3] = new JValue (p3);
				__args [4] = new JValue (p4);
				JNIEnv.CallStaticVoidMethod  (class_ref, id_arraycopy_arraySILpl_edu_icm_jlargearrays_UnsignedByteLargeArray_JJ, __args);
			} finally {
				if (p0 != null) {
					JNIEnv.CopyArray (native_p0, p0);
					JNIEnv.DeleteLocalRef (native_p0);
				}
			}
		}

		static IntPtr id_convert_Lpl_edu_icm_jlargearrays_LargeArray_Lpl_edu_icm_jlargearrays_LargeArrayType_;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='convert' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.LargeArray'] and parameter[2][@type='pl.edu.icm.jlargearrays.LargeArrayType']]"
		[Register ("convert", "(Lpl/edu/icm/jlargearrays/LargeArray;Lpl/edu/icm/jlargearrays/LargeArrayType;)Lpl/edu/icm/jlargearrays/LargeArray;", "")]
		public static unsafe global::PL.Edu.Icm.Jlargearrays.LargeArray Convert (global::PL.Edu.Icm.Jlargearrays.LargeArray p0, global::PL.Edu.Icm.Jlargearrays.LargeArrayType p1)
		{
			if (id_convert_Lpl_edu_icm_jlargearrays_LargeArray_Lpl_edu_icm_jlargearrays_LargeArrayType_ == IntPtr.Zero)
				id_convert_Lpl_edu_icm_jlargearrays_LargeArray_Lpl_edu_icm_jlargearrays_LargeArrayType_ = JNIEnv.GetStaticMethodID (class_ref, "convert", "(Lpl/edu/icm/jlargearrays/LargeArray;Lpl/edu/icm/jlargearrays/LargeArrayType;)Lpl/edu/icm/jlargearrays/LargeArray;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::PL.Edu.Icm.Jlargearrays.LargeArray __ret = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (JNIEnv.CallStaticObjectMethod  (class_ref, id_convert_Lpl_edu_icm_jlargearrays_LargeArray_Lpl_edu_icm_jlargearrays_LargeArrayType_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_create_Lpl_edu_icm_jlargearrays_LargeArrayType_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='create' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.LargeArrayType'] and parameter[2][@type='long']]"
		[Register ("create", "(Lpl/edu/icm/jlargearrays/LargeArrayType;J)Lpl/edu/icm/jlargearrays/LargeArray;", "")]
		public static unsafe global::PL.Edu.Icm.Jlargearrays.LargeArray Create (global::PL.Edu.Icm.Jlargearrays.LargeArrayType p0, long p1)
		{
			if (id_create_Lpl_edu_icm_jlargearrays_LargeArrayType_J == IntPtr.Zero)
				id_create_Lpl_edu_icm_jlargearrays_LargeArrayType_J = JNIEnv.GetStaticMethodID (class_ref, "create", "(Lpl/edu/icm/jlargearrays/LargeArrayType;J)Lpl/edu/icm/jlargearrays/LargeArray;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::PL.Edu.Icm.Jlargearrays.LargeArray __ret = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (JNIEnv.CallStaticObjectMethod  (class_ref, id_create_Lpl_edu_icm_jlargearrays_LargeArrayType_J, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_create_Lpl_edu_icm_jlargearrays_LargeArrayType_JZ;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='create' and count(parameter)=3 and parameter[1][@type='pl.edu.icm.jlargearrays.LargeArrayType'] and parameter[2][@type='long'] and parameter[3][@type='boolean']]"
		[Register ("create", "(Lpl/edu/icm/jlargearrays/LargeArrayType;JZ)Lpl/edu/icm/jlargearrays/LargeArray;", "")]
		public static unsafe global::PL.Edu.Icm.Jlargearrays.LargeArray Create (global::PL.Edu.Icm.Jlargearrays.LargeArrayType p0, long p1, bool p2)
		{
			if (id_create_Lpl_edu_icm_jlargearrays_LargeArrayType_JZ == IntPtr.Zero)
				id_create_Lpl_edu_icm_jlargearrays_LargeArrayType_JZ = JNIEnv.GetStaticMethodID (class_ref, "create", "(Lpl/edu/icm/jlargearrays/LargeArrayType;JZ)Lpl/edu/icm/jlargearrays/LargeArray;");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				global::PL.Edu.Icm.Jlargearrays.LargeArray __ret = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (JNIEnv.CallStaticObjectMethod  (class_ref, id_create_Lpl_edu_icm_jlargearrays_LargeArrayType_JZ, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_createConstant_Lpl_edu_icm_jlargearrays_LargeArrayType_JLjava_lang_Object_;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='createConstant' and count(parameter)=3 and parameter[1][@type='pl.edu.icm.jlargearrays.LargeArrayType'] and parameter[2][@type='long'] and parameter[3][@type='java.lang.Object']]"
		[Register ("createConstant", "(Lpl/edu/icm/jlargearrays/LargeArrayType;JLjava/lang/Object;)Lpl/edu/icm/jlargearrays/LargeArray;", "")]
		public static unsafe global::PL.Edu.Icm.Jlargearrays.LargeArray CreateConstant (global::PL.Edu.Icm.Jlargearrays.LargeArrayType p0, long p1, global::Java.Lang.Object p2)
		{
			if (id_createConstant_Lpl_edu_icm_jlargearrays_LargeArrayType_JLjava_lang_Object_ == IntPtr.Zero)
				id_createConstant_Lpl_edu_icm_jlargearrays_LargeArrayType_JLjava_lang_Object_ = JNIEnv.GetStaticMethodID (class_ref, "createConstant", "(Lpl/edu/icm/jlargearrays/LargeArrayType;JLjava/lang/Object;)Lpl/edu/icm/jlargearrays/LargeArray;");
			try {
				JValue* __args = stackalloc JValue [3];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				__args [2] = new JValue (p2);
				global::PL.Edu.Icm.Jlargearrays.LargeArray __ret = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (JNIEnv.CallStaticObjectMethod  (class_ref, id_createConstant_Lpl_edu_icm_jlargearrays_LargeArrayType_JLjava_lang_Object_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_generateRandom_Lpl_edu_icm_jlargearrays_LargeArrayType_J;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='generateRandom' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.LargeArrayType'] and parameter[2][@type='long']]"
		[Register ("generateRandom", "(Lpl/edu/icm/jlargearrays/LargeArrayType;J)Lpl/edu/icm/jlargearrays/LargeArray;", "")]
		public static unsafe global::PL.Edu.Icm.Jlargearrays.LargeArray GenerateRandom (global::PL.Edu.Icm.Jlargearrays.LargeArrayType p0, long p1)
		{
			if (id_generateRandom_Lpl_edu_icm_jlargearrays_LargeArrayType_J == IntPtr.Zero)
				id_generateRandom_Lpl_edu_icm_jlargearrays_LargeArrayType_J = JNIEnv.GetStaticMethodID (class_ref, "generateRandom", "(Lpl/edu/icm/jlargearrays/LargeArrayType;J)Lpl/edu/icm/jlargearrays/LargeArray;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::PL.Edu.Icm.Jlargearrays.LargeArray __ret = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (JNIEnv.CallStaticObjectMethod  (class_ref, id_generateRandom_Lpl_edu_icm_jlargearrays_LargeArrayType_J, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

		static IntPtr id_select_Lpl_edu_icm_jlargearrays_LargeArray_Lpl_edu_icm_jlargearrays_LogicLargeArray_;
		// Metadata.xml XPath method reference: path="/api/package[@name='pl.edu.icm.jlargearrays']/class[@name='LargeArrayUtils']/method[@name='select' and count(parameter)=2 and parameter[1][@type='pl.edu.icm.jlargearrays.LargeArray'] and parameter[2][@type='pl.edu.icm.jlargearrays.LogicLargeArray']]"
		[Register ("select", "(Lpl/edu/icm/jlargearrays/LargeArray;Lpl/edu/icm/jlargearrays/LogicLargeArray;)Lpl/edu/icm/jlargearrays/LargeArray;", "")]
		public static unsafe global::PL.Edu.Icm.Jlargearrays.LargeArray Select (global::PL.Edu.Icm.Jlargearrays.LargeArray p0, global::PL.Edu.Icm.Jlargearrays.LogicLargeArray p1)
		{
			if (id_select_Lpl_edu_icm_jlargearrays_LargeArray_Lpl_edu_icm_jlargearrays_LogicLargeArray_ == IntPtr.Zero)
				id_select_Lpl_edu_icm_jlargearrays_LargeArray_Lpl_edu_icm_jlargearrays_LogicLargeArray_ = JNIEnv.GetStaticMethodID (class_ref, "select", "(Lpl/edu/icm/jlargearrays/LargeArray;Lpl/edu/icm/jlargearrays/LogicLargeArray;)Lpl/edu/icm/jlargearrays/LargeArray;");
			try {
				JValue* __args = stackalloc JValue [2];
				__args [0] = new JValue (p0);
				__args [1] = new JValue (p1);
				global::PL.Edu.Icm.Jlargearrays.LargeArray __ret = global::Java.Lang.Object.GetObject<global::PL.Edu.Icm.Jlargearrays.LargeArray> (JNIEnv.CallStaticObjectMethod  (class_ref, id_select_Lpl_edu_icm_jlargearrays_LargeArray_Lpl_edu_icm_jlargearrays_LogicLargeArray_, __args), JniHandleOwnership.TransferLocalRef);
				return __ret;
			} finally {
			}
		}

	}
}
