﻿using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace LinqToDB.Async
{
	/// <summary>
	/// Asynchronous version of the <see cref="IDbTransaction"/> interface, allowing asynchronous operations, missing from <see cref="IDbTransaction"/>.
	/// </summary>
	[PublicAPI]
	public interface IAsyncDbTransaction : IDbTransaction
#if !NET45 && !NET46
		, IAsyncDisposable
#endif
	{
		/// <summary>
		/// Commits transaction asynchronously.
		/// </summary>
		/// <param name="cancellationToken">Asynchronous operation cancellation token.</param>
		/// <returns>Asynchronous operation completion task.</returns>
		Task CommitAsync(CancellationToken cancellationToken = default);

		/// <summary>
		/// Rollbacks transaction asynchronously.
		/// </summary>
		/// <param name="cancellationToken">Asynchronous operation cancellation token.</param>
		/// <returns>Asynchronous operation completion task.</returns>
		Task RollbackAsync(CancellationToken cancellationToken = default);

		/// <summary>
		/// Gets underlying transaction instance.
		/// </summary>
		IDbTransaction Transaction { get; }

#if NET45 || NET46
		/// <summary>
		/// Disposes transaction asynchronously.
		/// </summary>
		/// <returns>Asynchronous operation completion task.</returns>
		Task DisposeAsync();
#endif
	}
}
