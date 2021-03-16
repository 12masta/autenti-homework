using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using autenti_homework.Helpers;
using Microsoft.Extensions.Logging;
using PlaywrightSharp;
using Xunit;
using Xunit.Abstractions;

namespace autenti_homework
{
    public class BaseTest : IAsyncLifetime
    {
        /// <summary>
        /// Gets or sets the Page.
        /// </summary>
        protected IPage Page { get; set; }

        private IBrowserContext Context { get; set; }
        private IBrowser Browser => PlaywrightSharpBrowserLoaderFixture.Browser;
        
        /// <inheritdoc cref="IAsyncLifetime.InitializeAsync"/>
        public async Task InitializeAsync()
        {
            var playwrightSharpBrowserLoaderFixture = new PlaywrightSharpBrowserLoaderFixture();
            await playwrightSharpBrowserLoaderFixture.InitializeAsync();
            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();
        }

        public async Task DisposeAsync()
        {
            await Context.CloseAsync();
        }

        /// <summary>
        /// Wait for an error event.
        /// </summary>
        /// <returns>A <see cref="Task"/> that completes when the error is received</returns>
        protected Task WaitForError()
        {
            var wrapper = new TaskCompletionSource<bool>();

            void errorEvent(object sender, EventArgs e)
            {
                wrapper.SetResult(true);
                Page.Crash -= errorEvent;
            }

            Page.Crash += errorEvent;

            return wrapper.Task;
        }
    }
}