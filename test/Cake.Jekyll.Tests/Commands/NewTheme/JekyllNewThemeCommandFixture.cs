﻿#region Copyright 2021 C. Augusto Proiete & Contributors
//
// Licensed under the MIT (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://opensource.org/licenses/MIT
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion

using Cake.Jekyll.Commands.NewTheme;
using Cake.Jekyll.Tests.Support;

namespace Cake.Jekyll.Tests.Commands.NewTheme
{
    internal sealed class JekyllNewThemeCommandFixture : JekyllFixture<JekyllNewThemeSettings>
    {
        protected override void RunTool()
        {
            var tool = new JekyllNewThemeCommand(FileSystem, Environment, ProcessRunner, Tools, Log);
            tool.NewTheme(Settings);
        }
    }
}
