using System;
using System.Data.Common;

namespace BackEndPreguntas.Commands
{
	public static class DbCommandExtension
	{
		public static DbParameter AddParameterWithValue(this DbCommand command, String parameterName, Object value)
		{
			DbParameter parameter = command.CreateParameter();
			parameter.ParameterName = parameterName;
			parameter.Value = value;
			command.Parameters.Add(parameter);
			return parameter;
		}
	}
}
