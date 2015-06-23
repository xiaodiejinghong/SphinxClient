namespace Jhong.SphinxClient.DataStructure
{
    using Jhong.SphinxClient.Extension;
    using System;
    using System.Text;

    /// <summary>
    /// 请求结构
    /// </summary>
    internal class SphReq
    {
        /// <summary>
        ///
        /// </summary>
        internal class Block
        {
            internal byte[] Data;
            internal Block Next;
        }

        /// <summary>
        /// 拼接位置
        /// </summary>
        internal enum BlockMosaicLocation
        {
            /// <summary>
            /// 最前
            /// </summary>
            Top,

            /// <summary>
            /// 最后
            /// </summary>
            Bottom
        }

        /// <summary>
        ///
        /// </summary>
        private Block _current;

        /// <summary>
        ///
        /// </summary>
        private Block _next;

        /// <summary>
        /// 数据块总数
        /// </summary>
        internal int BlockCount
        {
            get
            {
                var curr = this._next;
                var count = 0;
                while (null != curr)
                {
                    count++;
                    curr = curr.Next;
                }
                return count;
            }
        }

        /// <summary>
        /// 数据总长度
        /// </summary>
        internal long Length
        {
            get
            {
                var curr = this._next;
                long length = 0;
                while (null != curr)
                {
                    length += curr.Data.Length;
                    curr = curr.Next;
                }
                return length;
            }
        }

        /// <summary>
        /// 追加数据块
        /// </summary>
        /// <param name="block"></param>
        private void Append(Block block)
        {
            if (null == this._next) this._next = this._current;
            if (null != this._current) this._current.Next = block;
            this._current = block;
        }

        /// <summary>
        /// 删除Head
        /// </summary>
        /// <returns></returns>
        internal Block CutOffHead()
        {
            return this._next;
        }

        /// <summary>
        /// 读取数据链
        /// </summary>
        /// <returns></returns>
        internal byte[] GetBuffer()
        {
            var buffer = new byte[this.Length];
            var curr = this._next;
            var index = 0;
            while (null != curr)
            {
                Array.Copy(curr.Data, 0, buffer, index, curr.Data.Length);
                index += curr.Data.Length;
                curr = curr.Next;
            }
            return buffer;
        }

        /// <summary>
        /// 拼接Req链
        /// </summary>
        /// <param name="input">第一块数据块地址</param>
        /// <param name="location">拼接模式</param>
        internal void Mosaic(object input, BlockMosaicLocation location = BlockMosaicLocation.Bottom)
        {
            if (false == (input is Block)) throw new Exception("The input is not 'Block' Type");
            var block = input as Block;
            switch (location)
            {
                case BlockMosaicLocation.Bottom:
                    this._current.Next = block;
                    while (null != this._current.Next) this._current = this._current.Next;
                    break;

                case BlockMosaicLocation.Top:
                    var curr = block;
                    while (null != curr.Next) curr = curr.Next;
                    curr.Next = this._next;
                    this._next = block;
                    break;
            }
        }

        /// <summary>
        /// 写入一个Int16短整形
        /// </summary>
        /// <param name="value"></param>
        internal void Write(short value)
        {
            var block = new Block()
            {
                Data = BitConverter.GetBytes(value).ReverseX()
            };
            this.Append(block);
        }

        /// <summary>
        /// 写入一个Int32整形
        /// </summary>
        /// <param name="value"></param>
        internal void Write(int value)
        {
            var block = new Block()
            {
                Data = BitConverter.GetBytes(value).ReverseX()
            };
            this.Append(block);
        }

        /// <summary>
        /// 写入一个字符串
        /// </summary>
        /// <param name="value"></param>
        internal void Write(string value)
        {
            var buffer = Encoding.UTF8.GetBytes(value);
            this.Write(buffer.Length);
            var block = new Block()
            {
                Data = buffer
            };
            this.Append(block);
        }

        /// <summary>
        /// 写入一个单精度浮点数
        /// </summary>
        /// <param name="value"></param>
        internal void Write(float value)
        {
            var block = new Block()
            {
                Data = BitConverter.GetBytes(value)
            };
            this.Append(block);
        }

        /// <summary>
        /// 写入一个Int64的整数
        /// </summary>
        /// <param name="value"></param>
        internal void Write(long value)
        {
            var block = new Block()
            {
                Data = BitConverter.GetBytes(value)
            };
            this.Append(block);
        }
    }
}