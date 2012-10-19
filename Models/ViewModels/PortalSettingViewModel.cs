// <copyright file="PortalSettingViewModel.cs" company="Engage Software">
// Engage: Take-Out
// Copyright (c) 2004-2012
// by Engage Software ( http://www.engagesoftware.com )
// </copyright>
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.

namespace Engage.Dnn.TakeOut
{
    using System;

    /// <summary>Represents a single portal setting</summary>
    public struct PortalSettingViewModel : IEquatable<PortalSettingViewModel>
    {
        /// <summary>Initializes a new instance of the <see cref="PortalSettingViewModel" /> struct.</summary>
        /// <param name="settingName">Name of the setting.</param>
        /// <param name="selected">if set to <c>true</c> this settings has been selected to be exported.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="settingName"/> is <c>null</c></exception>
        public PortalSettingViewModel(string settingName, bool selected)
            : this()
        {
            if (settingName == null)
            {
                throw new ArgumentNullException("settingName");
            }

            this.SettingName = settingName;
            this.Selected = selected;
        }

        /// <summary>Gets the name of the setting.</summary>
        /// <value>The name of the setting.</value>
        public string SettingName { get; private set; }

        /// <summary>Gets a value indicating whether this setting is selected for export.</summary>
        /// <value><c>true</c> if selected; otherwise, <c>false</c>.</value>
        public bool Selected { get; private set; }

        /// <summary>Implements the ==.</summary>
        /// <param name="left">The left side of the operator.</param>
        /// <param name="right">The right side of the operator.</param>
        /// <returns><c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public static bool operator ==(PortalSettingViewModel left, PortalSettingViewModel right)
        {
            return left.Equals(right);
        }

        /// <summary>Implements the !=.</summary>
        /// <param name="left">The left side of the operator.</param>
        /// <param name="right">The right side of the operator.</param>
        /// <returns><c>true</c> if the specified <see cref="object" /> is not equal to this instance; otherwise, <c>false</c>.</returns>
        public static bool operator !=(PortalSettingViewModel left, PortalSettingViewModel right)
        {
            return !left.Equals(right);
        }

        /// <summary>Determines whether the specified <see cref="PortalSettingViewModel" /> is equal to this instance.</summary>
        /// <param name="other">The other instance.</param>
        /// <returns><c>true</c> if the specified <see cref="PortalSettingViewModel" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public bool Equals(PortalSettingViewModel other)
        {
            return string.Equals(this.SettingName, other.SettingName, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>Determines whether the specified <see cref="object" /> is equal to this instance.</summary>
        /// <param name="obj">Another object to compare to.</param>
        /// <returns><c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is PortalSettingViewModel && this.Equals((PortalSettingViewModel)obj);
        }

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return this.SettingName.GetHashCode();
        }
    }
}