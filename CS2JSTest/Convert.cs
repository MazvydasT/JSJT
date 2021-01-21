using System;
using System.Linq;

public static class Convert
{
	public static byte[] ToBytes<T>(T value)
	{
		var inputTypeName = typeof(T).Name;

		switch(inputTypeName)
		{
			case "Byte": return new[] { (byte)(object)value };
			case "SByte": return new[] { (byte)(object)value };
			case "Char": return BitConverter.GetBytes((Char)(object)value);
			case "Int16": return BitConverter.GetBytes((Int16)(object)value);
			case "UInt16": return BitConverter.GetBytes((UInt16)(object)value);
			case "Int32": return BitConverter.GetBytes((Int32)(object)value);
			case "UInt32": return BitConverter.GetBytes((UInt32)(object)value);
			case "Int64": return BitConverter.GetBytes((Int64)(object)value);
			case "UInt64": return BitConverter.GetBytes((UInt64)(object)value);
			case "Double": return BitConverter.GetBytes((Double)(object)value);
			case "Single": return BitConverter.GetBytes((Single)(object)value);
			default: throw new NotSupportedException($"Input type <{inputTypeName}> is not one of: Byte, SByte, Char, Int16, UInt16, Int32, UInt32, Int64, UInt64, Double, Single");
		}
	}

	public static byte[] ToBytes<T>(T[] values) => values?.SelectMany(v => ToBytes<T>(v)).ToArray();

	public static T FromBytes<T>(byte[] bytes)
	{
		if (bytes == null) throw new ArgumentNullException(nameof(bytes), $"{nameof(bytes)} is null");

		var returnTypeName = typeof(T).Name;

		switch (returnTypeName)
		{
			case "Byte": return bytes.Length == 1 ?
				(T)(object) bytes[0] :
				throw new ArgumentException($"{nameof(bytes)}.Length should be 1 for {nameof(FromBytes)}<Byte>");

			case "SByte": return bytes.Length == 1 ?
				(T)(object) bytes[0] :
				throw new ArgumentException($"{nameof(bytes)}.Length should be 1 for {nameof(FromBytes)}<SByte>");

			case "Char": return bytes.Length == 2 ?
				(T)(object) BitConverter.ToChar(bytes, 0) :
				throw new ArgumentException($"{nameof(bytes)}.Length should be 2 for {nameof(FromBytes)}<Char>");

			case "Int16": return bytes.Length == 2 ?
				(T)(object) BitConverter.ToInt16(bytes, 0) :
				throw new ArgumentException($"{nameof(bytes)}.Length should be 2 for {nameof(FromBytes)}<Int16>");

			case "UInt16": return bytes.Length == 2 ?
				(T)(object) BitConverter.ToUInt16(bytes, 0) :
				throw new ArgumentException($"{nameof(bytes)}.Length should be 2 for {nameof(FromBytes)}<UInt16>");

			case "Int32": return bytes.Length == 4 ?
				(T)(object) BitConverter.ToInt32(bytes, 0) :
				throw new ArgumentException($"{nameof(bytes)}.Length should be 4 for {nameof(FromBytes)}<Int32>");

			case "UInt32": return bytes.Length == 4 ?
				(T)(object) BitConverter.ToUInt32(bytes, 0) :
				throw new ArgumentException($"{nameof(bytes)}.Length should be 4 for {nameof(FromBytes)}<UInt32>");

			case "Int64": return bytes.Length == 8 ?
				(T)(object) BitConverter.ToInt64(bytes, 0) :
				throw new ArgumentException($"{nameof(bytes)}.Length should be 8 for {nameof(FromBytes)}<Int64>");

			case "UInt64": return bytes.Length == 8 ?
				(T)(object) BitConverter.ToUInt64(bytes, 0) :
				throw new ArgumentException($"{nameof(bytes)}.Length should be 8 for {nameof(FromBytes)}<UInt64>");

			case "Double": return bytes.Length == 8 ?
				(T)(object) BitConverter.ToDouble(bytes, 0) :
				throw new ArgumentException($"{nameof(bytes)}.Length should be 8 for {nameof(FromBytes)}<Double>");

			case "Single": return bytes.Length == 4 ?
				(T)(object) BitConverter.ToSingle(bytes, 0) :
				throw new ArgumentException($"{nameof(bytes)}.Length should be 4 for {nameof(FromBytes)}<Single>");

			default: throw new NotSupportedException($"Return type <{returnTypeName}> is not one of: Byte, SByte, Char, Int16, UInt16, Int32, UInt32, Int64, UInt64, Double, Single");
		}
	}
}