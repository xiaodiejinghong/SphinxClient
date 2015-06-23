namespace Jhong.SphinxClient.DataStructure
{
    using Extension;
    using System;
    using System.Text;

    /// <summary>
    /// 响应结构
    /// </summary>
    internal class SphRep
    {
        /// <summary>
        ///
        /// </summary>
        private byte[] _data;

        /// <summary>
        /// 字串长度
        /// </summary>
        internal long Length { get; private set; }

        /// <summary>
        /// 当前位置
        /// </summary>
        internal long Current { get; private set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="length">总长度</param>
        internal SphRep(byte[] data, long length)
        {
            this._data = data;
            this.Length = length;
            this.Current = 0;
        }

        /// <summary>
        /// 溢出检测
        /// </summary>
        /// <param name="readLength"></param>
        private void CheckRead(int readLength)
        {
            if (Current + readLength > Length) throw new IndexOutOfRangeException("Ouch!！It out of Range");
        }

        /// <summary>
        /// 读length长度的字节
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        internal byte[] Read(int length)
        {
            this.CheckRead(length);
            var buffer = new byte[length];
            Array.Copy(this._data, this.Current, buffer, 0, length);
            this.Current += length;
            return buffer;
        }

        /// <summary>
        /// 读取一个Int32整形
        /// </summary>
        /// <returns></returns>
        internal int ReadInt()
        {
            return BitConverter.ToInt32(this.Read(4).ReverseX(), 0);
        }

        /// <summary>
        /// 读取一个Int64长整形
        /// </summary>
        /// <returns></returns>
        internal long ReadLong()
        {
            return BitConverter.ToInt64(this.Read(8).ReverseX(), 0);
        }

        /// <summary>
        /// 读取一个Int16短整形
        /// </summary>
        /// <returns></returns>
        internal short ReadShort()
        {
            return BitConverter.ToInt16(this.Read(2).ReverseX(), 0);
        }

        /// <summary>
        /// 读取一个单精度
        /// </summary>
        /// <returns></returns>
        internal float ReadSingle()
        {
            return BitConverter.ToSingle(this.Read(4).ReverseX(), 0);
        }

        /// <summary>
        /// 读取一个字符串节点
        /// </summary>
        /// <returns></returns>
        internal string ReadStringNode()
        {
            var len = this.ReadInt();
            var str = Encoding.UTF8.GetString(this._data, (int)this.Current, len);
            this.Current += len;
            return str;
        }
    }
}