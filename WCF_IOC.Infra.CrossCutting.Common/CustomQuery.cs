//===================================================================================
// © GABRIELGI - linkedin.com/in/gabrielgonzaleziglesias
//===================================================================================

#region

using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Xml.Linq;
using WCF_IOC.Infra.CrossCutting.Common.ExpressionTreeSerialization;

#endregion

namespace WCF_IOC.Infra.CrossCutting.Common
{
    [DataContract]
    public class CustomQuery<TEntity>
    {
        #region Properties

        [DataMember]
        public string SerializedExpression { get; set; } 

        #endregion

        #region Constructors

        public CustomQuery() { }

        public CustomQuery(Expression<Func<TEntity, bool>> expresion)
        {
            var predicate = (Expression<Func<TEntity, bool>>)ExpressionBuilder.ReplaceFilterValues(expresion);
            SerializedExpression = new ExpressionSerializer().Serialize(predicate).ToString();
        } 

        #endregion

        #region Public Methods

        public Expression<Func<TEntity, bool>> ToDomainExpression()
        {
            if (SerializedExpression == null)
                throw new ArgumentException("SerializedExpression");

            // It's need because AutoMapper doesn't know map dto to domain entities...
            var domainExpression = SerializedExpression.Replace("Application.BoundedContext.Dtos", "Domain.BoundedContext.Entities");
            
            var aux = XElement.Parse(domainExpression);
            return new ExpressionSerializer().Deserialize<Func<TEntity, bool>>(aux);
        } 

        #endregion
    }
}