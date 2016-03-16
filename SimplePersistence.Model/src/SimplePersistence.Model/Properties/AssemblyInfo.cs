#region License
// The MIT License (MIT)
// 
// Copyright (c) 2016 SimplePersistence
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

using System;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("SimplePersistence.Model")]

[assembly: AssemblyDescription("Library with helper interfaces and classes to provide consistency across application models. Implementations are ORM compatible and should be usable in most databases.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Net.JoaoSimoes")]
[assembly: AssemblyProduct("SimplePersistence")]
[assembly: AssemblyCopyright("Copyright © 2016 SimplePersistence")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

#if !(PORTABLE40 || PORTABLE)

[assembly: ComVisible(false)]

[assembly: Guid("26bf2ceb-dec6-43c8-a94d-6d993ea9ffe6")]

#endif

[assembly: CLSCompliant(true)]

[assembly: AssemblyVersion("3.0.3")]
[assembly: AssemblyInformationalVersion("3.0.3")]
