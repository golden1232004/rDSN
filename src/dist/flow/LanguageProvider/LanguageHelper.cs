/*
 * The MIT License (MIT)
 *
 * Copyright (c) 2015 Microsoft Corporation
 * 
 * -=- Robust Distributed System Nucleus (rDSN) -=- 
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

/*
 * Description:
 *     What is this file about?
 *
 * Revision history:
 *     Feb., 2016, @imzhenyu (Zhenyu Guo), done in Tron project and copied here
 *     xxxx-xx-xx, author, fix bug about xxx
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace rDSN.Tron.LanguageProvider
{
   public class LanguageHelper
   {
       public static string GetSourceExtension(ClientLanguage lang)
       {
           var map = new Dictionary<ClientLanguage, string>
           {
                {ClientLanguage.Client_CPlusPlus, "cpp"},
                {ClientLanguage.Client_CSharp, "cs"},
                {ClientLanguage.Client_Java, "java"},
                {ClientLanguage.Client_Python, "py"},
                {ClientLanguage.Client_Javascript, "js"}
            };
           return map.ContainsKey(lang) ? map[lang] : "";
       }

       // TODO: return the correct path of compiler in Linux platform
       public static string GetCompilerPath(ServiceSpecType t, ClientPlatform p = ClientPlatform.Windows)
       {
           var path = "";
           var prefix = Path.Combine(Environment.GetEnvironmentVariable("DSN_ROOT"), "bin/windows");
           switch(t)
           {
               case ServiceSpecType.Proto:
                   path = Path.Combine(prefix, "protoc.exe");
                   break;
               case ServiceSpecType.Thrift:
                   path = Path.Combine(prefix, "thrift.exe");
                   break;
               case ServiceSpecType.Bond30:
                   path = Path.Combine(prefix, "bondc.exe");
                   break;
               default:
                   break;
           }

           if (File.Exists(path))
           {
               return path;
           }

           Console.WriteLine($"Cannot find {t.ToString()} compiler at path: {path}!");
           return "";
       }
   }
  
}
