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

using Cake.Core.IO;
using Cake.Jekyll.Core.IO;

namespace Cake.Jekyll.Commands.New
{
    /// <summary>
    /// Contains settings used by <see cref="JekyllNewCommand"/>.
    /// </summary>
    public class JekyllNewSettings : JekyllSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JekyllNewSettings"/> class.
        /// </summary>
        public JekyllNewSettings()
            : base("new")
        {
        }

        /// <summary>
        /// Path to scaffold the site.
        /// </summary>
        public DirectoryPath Path { get; internal set; }

        /// <summary>
        /// Force creation even if PATH already exists (defaults to <see langword="false"/>).
        /// --force
        /// </summary>
        public bool? Force { get; set; }

        /// <summary>
        /// Creates scaffolding but with empty files (defaults to <see langword="false"/>).
        /// --blank
        /// </summary>
        public bool? Blank { get; set; }

        /// <summary>
        /// Skip `bundle install` (defaults to <see langword="false"/>).
        /// --skip-bundle
        /// </summary>
        public bool? SkipBundle { get; set; }

        /// <summary>
        /// Site Source directory, the directory where Jekyll will read files (defaults to `./`).
        /// -s, --source DIR
        /// </summary>
        public DirectoryPath Source { get; set; }

        /// <summary>
        /// Site Destination directory, the directory where Jekyll will write files (defaults to `./_site`).
        /// -d, --destination DIR
        /// 
        /// Important: The contents of <see cref="Destination"/> are automatically cleaned, by default, when the site is built.
        /// Files or folders that are not created by your site will be removed.
        /// Some files could be retained by specifying them within the `keep_files` configuration directive.
        /// Do not use an important location for <see cref="Destination"/>; instead, use it as a staging area and copy files from there to your web server.
        /// </summary>
        public DirectoryPath Destination { get; set; }

        /// <summary>
        /// Safe mode (defaults to <see langword="false"/>).
        /// --safe
        /// 
        /// Disable non-whitelisted plugins, caching to disk, and ignore symbolic links.
        /// </summary>
        public bool? SafeMode { get; set; }

        /// <summary>
        /// Specifies plugin directories instead of using `_plugins/` automatically.
        /// -p, --plugins DIR1[,DIR2,...]
        /// </summary>
        public OneOrMoreDirectoryPaths Plugins { get; set; }

        /// <summary>
        /// Specifies layout directory instead of using `_layouts/` automatically.
        /// --layouts DIR
        /// </summary>
        public DirectoryPath Layouts { get; set; }

        /// <summary>
        /// Generate a Liquid rendering profile to help you identify performance bottlenecks.
        /// --profile
        /// </summary>
        public bool? LiquidProfile { get; set; }

        /// <summary>
        /// Show the full backtrace when an error occurs.
        /// -t, --trace
        /// </summary>
        public bool? Trace { get; set; }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);

            ApplyValue(args, Path?.FullPath);
            ApplyOption(args, "--force", Force);
            ApplyOption(args, "--blank", Blank);
            ApplyOption(args, "--skip-bundle", SkipBundle);
            ApplyOption(args, "--source", Source?.FullPath);
            ApplyOption(args, "--destination", Destination?.FullPath);
            ApplyOption(args, "--safe", SafeMode);
            ApplyOption(args, "--plugins", Plugins);
            ApplyOption(args, "--layouts", Layouts?.FullPath);
            ApplyOption(args, "--profile", LiquidProfile);
            ApplyOption(args, "--trace", Trace);
        }
    }
}
