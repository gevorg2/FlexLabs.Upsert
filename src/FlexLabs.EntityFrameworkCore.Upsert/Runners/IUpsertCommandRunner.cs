﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlexLabs.EntityFrameworkCore.Upsert.Runners
{
    /// <summary>
    /// Upsert command runner base interface
    /// </summary>
    public interface IUpsertCommandRunner
    {
        /// <summary>
        /// Specifies whether this command runner supports a specific database provider
        /// </summary>
        /// <param name="name">Name of the database provider</param>
        /// <returns>true if this runner supports the database provider specified; otherwise false</returns>
        bool Supports(string name);

        /// <summary>
        /// Run the upsert command for the entities passed
        /// </summary>
        /// <typeparam name="TEntity">Entity type of the entities</typeparam>
        /// <param name="dbContext">Data context to be used</param>
        /// <param name="entityType">Metadata for the entity</param>
        /// <param name="entities">Array of entities to be upserted</param>
        /// <param name="matchExpression">Expression that represents which properties will be used as a match clause for the upsert command</param>
        /// <param name="updateExpression">Expression that represents which properties will be updated, and what values will be set</param>
        /// <param name="updateCondition">Expression that checks whether the database entry should be updated</param>
        /// <param name="noUpdate">Specifies that if a match is found, no action will be taken on the entity</param>
        /// <param name="useExpressionCompiler">If true, will fallback to the (slower) expression compiler for unhandled update expressions</param>
        /// <param name="excludedFieldsToNotCompare"></param>
        /// <param name="delete"></param>
        /// <param name="deleteCondition"></param>
        int Run<TEntity>(DbContext dbContext, IEntityType entityType, ICollection<TEntity> entities,
            Expression<Func<TEntity, object>> matchExpression,
            Expression<Func<TEntity, TEntity, TEntity>> updateExpression,
            Expression<Func<TEntity, TEntity, bool>> updateCondition, bool noUpdate, bool useExpressionCompiler,
            IList<PropertyInfo> excludedFieldsToNotCompare, bool delete, Expression<Func<TEntity, bool>> deleteCondition)
            where TEntity : class;

        /// <summary>
        /// Run the upsert command for the entities passed
        /// </summary>
        /// <typeparam name="TEntity">Entity type of the entities</typeparam>
        /// <param name="dbContext">Data context to be used</param>
        /// <param name="entityType">Metadata for the entity</param>
        /// <param name="entities">Array of entities to be upserted</param>
        /// <param name="matchExpression">Expression that represents which properties will be used as a match clause for the upsert command</param>
        /// <param name="updateExpression">Expression that represents which properties will be updated, and what values will be set</param>
        /// <param name="updateCondition">Expression that checks whether the database entry should be updated</param>
        /// <param name="noUpdate">Specifies that if a match is found, no action will be taken on the entity</param>
        /// <param name="useExpressionCompiler">If true, will fallback to the (slower) expression compiler for unhandled update expressions</param>
        /// <param name="excludedFieldsToNotCompare"></param>
        /// <param name="deleteCondition"></param>
        /// <param name="cancellationToken">The CancellationToken to observe while waiting for the task to complete.</param>
        /// <param name="delete"></param>
        /// <returns>The task that represents the asynchronous upsert operation</returns>
        Task<int> RunAsync<TEntity>(DbContext dbContext, IEntityType entityType, ICollection<TEntity> entities,
            Expression<Func<TEntity, object>> matchExpression,
            Expression<Func<TEntity, TEntity, TEntity>> updateExpression,
            Expression<Func<TEntity, TEntity, bool>> updateCondition, bool noUpdate, bool useExpressionCompiler,
            IList<PropertyInfo> excludedFieldsToNotCompare, bool delete, Expression<Func<TEntity, bool>> deleteCondition,
            CancellationToken cancellationToken) where TEntity : class;
    }
}
