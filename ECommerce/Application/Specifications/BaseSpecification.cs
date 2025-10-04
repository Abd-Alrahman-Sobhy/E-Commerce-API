using System.Linq.Expressions;

namespace Application.Specifications;

public class BaseSpecification<TEntity>
{
	public Expression<Func<TEntity, bool>>? Criteria { get; private set; }

	public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();

	public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderBy { get; private set; }

	public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderByDescending { get; private set; }

	protected void AddCriteria(Expression<Func<TEntity, bool>> criteria)
	{
		if (Criteria == null)
			Criteria = criteria;
		else
		{
			var param = Expression.Parameter(typeof(TEntity));
			var body = Expression.AndAlso(
				Expression.Invoke(Criteria, param),
				Expression.Invoke(criteria, param)
			);
			Criteria = Expression.Lambda<Func<TEntity, bool>>(body, param);
		}
	}

	protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
	{
		Includes.Add(includeExpression);
	}

	protected void ApplyOrderBy(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
	{
		OrderBy = orderBy;
	}

	protected void ApplyOrderByDescending(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderByDesc)
	{
		OrderByDescending = orderByDesc;
	}
}
