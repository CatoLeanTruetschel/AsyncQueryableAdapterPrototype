// License
// --------------------------------------------------------------------------------------------------------------------
// (C) Copyright 2021 Cato Léan Trütschel and contributors
// (github.com/CatoLeanTruetschel/AsyncQueryableAdapterPrototype)
//
// Licensed under the Apache License, Version 2.0 (the "License")
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// --------------------------------------------------------------------------------------------------------------------

// Based on
// --------------------------------------------------------------------------------------------------------------------
// Mono.Linq.Expressions
// https://github.com/jbevain/mono.linq.expressions
// (C) 2010 Novell, Inc. (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following tests:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;

namespace AsyncQueryableAdapter.Utils
{
    internal class TextWriterFormatter : IFormatter
    {
        private readonly TextWriter _writer;
        private bool _writeIndent;
        private int _indent;

        public TextWriterFormatter(TextWriter writer)
        {
            if (writer is null)
                throw new ArgumentNullException(nameof(writer));

            _writer = writer;
        }

        private void WriteIndent()
        {
            if (!_writeIndent)
                return;

            for (var i = 0; i < _indent; i++)
                _writer.Write("\t");
        }

        public void Write(string str)
        {
            WriteIndent();
            _writer.Write(str);
            _writeIndent = false;
        }

        public void WriteLine()
        {
            _writer.WriteLine();
            _writeIndent = true;
        }

        public void WriteSpace()
        {
            Write(" ");
        }

        public void WriteToken(string token)
        {
            Write(token);
        }

        public void WriteToken(char token)
        {
            WriteIndent();
            _writer.Write(token);
            _writeIndent = false;
        }

        public void WriteKeyword(string keyword)
        {
            Write(keyword);
        }

        public void WriteLiteral(string literal)
        {
            Write(literal);
        }

        public void WriteReference(string value, object reference)
        {
            Write(value);
        }

        public void WriteIdentifier(string value, object identifier)
        {
            Write(value);
        }

        public void Indent()
        {
            _indent++;
        }

        public void Dedent()
        {
            _indent--;
        }
    }
}
