﻿using System;

namespace SolidSoft.AMFCore.Util
{
	/// <summary>
	/// This type supports the AMFCore infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class DisposableBase : IDisposable
	{
		/// <summary>
		/// Tracks whether Dispose has been called.
		/// </summary>
        private volatile bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the DisposableBase class.
        /// </summary>
		public DisposableBase()
		{
		}

		/// <summary>
		/// Finalizer.
		/// Do not provide destructors in types derived from this class.
		/// </summary>
		~DisposableBase()
		{
			Dispose(false);
		}

        /// <summary>
        /// Gets a value indicating whether the object is disposed.
        /// </summary>
		public bool IsDisposed{ get{ return _disposed; } }

		#region IDisposable Members

        /// <summary>
        /// Releases all resources used by this object.
        /// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Dispose executes in two distinct scenarios:
		/// If disposing equals true, the method has been called directly
		/// or indirectly by a user's code. Managed and unmanaged resources can be disposed.
		/// If disposing equals false, the method has been called by the 
		/// runtime from inside the finalizer and you should not reference 
		/// other objects. Only unmanaged resources can be disposed.
		/// </summary>
		/// <param name="disposing"></param>
		protected virtual void Dispose(bool disposing)
		{
			if(!_disposed)
			{
				// if this is a dispose call dispose on all state you
				// hold, and take yourself off the Finalization queue.
				if (disposing)
				{
					Free();
				}
				// Free unmanaged objects
				FreeUnmanaged();
				_disposed = true;
			}
        }

        #endregion

        /// <summary>
		/// Free managed resources.
		/// </summary>
		protected virtual void Free()
		{
		}

		/// <summary>
		/// Free managed resources.
		/// </summary>
		protected virtual void FreeUnmanaged()
		{
		}
        /// <summary>
        /// Check whether object is disposed.
        /// </summary>
        /// <remarks>Throws ObjectDisposedException if the object is disposed.</remarks>
		protected virtual void CheckDisposed()
		{
			if(_disposed)
				throw new ObjectDisposedException(null);
		}
	}
}