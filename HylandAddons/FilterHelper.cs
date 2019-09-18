using Hyland.Unity.WorkView;

namespace HylandAddons
{
    public static class FilterHelper
    {
        /// <summary>
        /// Adds a list of constraints to a filter grouped together in parenthesis and Or connectors
        /// </summary>
        /// <param name="query">The filter query the constraints should be added to</param>
        /// <param name="dottedAddress">The desired string address that constraints should be added to</param>
        /// <param name="wvOperator">The operator to be used between the address and value</param>
        /// <param name="values">The values that should be used for the grouping</param>
        public static void AddGroupedConstraints(this ModifiableFilterQuery query, string dottedAddress, Operator wvOperator, params long[] values)
        {
            // If no values given, add not constraints and return
            if (values.Length == 0) return;

            // If only one value given, add it with no special grouping and return
            if (values.Length == 1)
            {
                query.AddConstraint(dottedAddress, wvOperator, values[0]);
                return;
            }

            // Add the first constraint and open the parenthesis
            query.AddConstraint(dottedAddress, wvOperator, values[0], Connector.OrConnector, Grouping.OpenParenthesis);

            // Add all middle constraints with an Or connector and no parenthesis
            for (int i = 1; i < values.Length - 1; i++)
            {
                query.AddConstraint(dottedAddress, wvOperator, values[i], Connector.OrConnector, Grouping.NoParenthesis);
            }

            // Add final constraint with a closing parenthesis and an And connector (design decision)
            query.AddConstraint(dottedAddress, wvOperator, values[values.Length - 1], Connector.AndConnector, Grouping.CloseParenthesis);
        }

        /// <summary>
        /// Adds a list of constraints to a filter grouped together in parenthesis and Or connectors
        /// </summary>
        /// <param name="query">The filter query the constraints should be added to</param>
        /// <param name="dottedAddress">The desired string address that constraints should be added to</param>
        /// <param name="wvOperator">The operator to be used between the address and value</param>
        /// <param name="values">The values that should be used for the grouping</param>
        public static void AddGroupedConstraints(this ModifiableFilterQuery query, string dottedAddress, Operator wvOperator, params string[] values)
        {
            // If no values given, add not constraints and return
            if (values.Length == 0) return;

            // If only one value given, add it with no special grouping and return
            if (values.Length == 1)
            {
                query.AddConstraint(dottedAddress, wvOperator, values[0]);
                return;
            }

            // Add the first constraint and open the parenthesis
            query.AddConstraint(dottedAddress, wvOperator, values[0], Connector.OrConnector, Grouping.OpenParenthesis);

            // Add all middle constraints with an Or connector and no parenthesis
            for (int i = 1; i < values.Length - 1; i++)
            {
                query.AddConstraint(dottedAddress, wvOperator, values[i], Connector.OrConnector, Grouping.NoParenthesis);
            }

            // Add final constraint with a closing parenthesis and an And connector (design decision)
            query.AddConstraint(dottedAddress, wvOperator, values[values.Length - 1], Connector.AndConnector, Grouping.CloseParenthesis);
        }

        /// <summary>
        /// Adds a list of constraints to a filter grouped together in parenthesis and Or connectors
        /// </summary>
        /// <param name="query">The filter query the constraints should be added to</param>
        /// <param name="dottedAddress">The desired string address that constraints should be added to</param>
        /// <param name="wvOperator">The operator to be used between the address and value</param>
        /// <param name="values">The values that should be used for the grouping</param>
        public static void AddGroupedConstraints(this ModifiableFilterQuery query, string dottedAddress, Operator wvOperator, params float[] values)
        {
            // If no values given, add not constraints and return
            if (values.Length == 0) return;

            // If only one value given, add it with no special grouping and return
            if (values.Length == 1)
            {
                query.AddConstraint(dottedAddress, wvOperator, values[0]);
                return;
            }

            // Add the first constraint and open the parenthesis
            query.AddConstraint(dottedAddress, wvOperator, values[0], Connector.OrConnector, Grouping.OpenParenthesis);

            // Add all middle constraints with an Or connector and no parenthesis
            for (int i = 1; i < values.Length - 1; i++)
            {
                query.AddConstraint(dottedAddress, wvOperator, values[i], Connector.OrConnector, Grouping.NoParenthesis);
            }

            // Add final constraint with a closing parenthesis and an And connector (design decision)
            query.AddConstraint(dottedAddress, wvOperator, values[values.Length - 1], Connector.AndConnector, Grouping.CloseParenthesis);
        }

        public static void AddGroupedConstraints(this ModifiableFilterQuery query, string dottedAddress, Operator wvOperator, params decimal[] values)
        {
            // If no values given, add not constraints and return
            if (values.Length == 0) return;

            // If only one value given, add it with no special grouping and return
            if (values.Length == 1)
            {
                query.AddConstraint(dottedAddress, wvOperator, values[0]);
                return;
            }

            // Add the first constraint and open the parenthesis
            query.AddConstraint(dottedAddress, wvOperator, values[0], Connector.OrConnector, Grouping.OpenParenthesis);

            // Add all middle constraints with an Or connector and no parenthesis
            for (int i = 1; i < values.Length - 1; i++)
            {
                query.AddConstraint(dottedAddress, wvOperator, values[i], Connector.OrConnector, Grouping.NoParenthesis);
            }

            // Add final constraint with a closing parenthesis and an And connector (design decision)
            query.AddConstraint(dottedAddress, wvOperator, values[values.Length - 1], Connector.AndConnector, Grouping.CloseParenthesis);
        }

        /// <summary>
        /// Adds a list of constraints to a filter grouped together in parenthesis and Or connectors
        /// </summary>
        /// <param name="query">The filter query the constraints should be added to</param>
        /// <param name="dottedAddress">The desired string address that constraints should be added to</param>
        /// <param name="wvOperator">The operator to be used between the address and value</param>
        /// <param name="values">The values that should be used for the grouping</param>
        public static void AddGroupedConstraints(this ModifiableFilterQuery query, string dottedAddress, Operator wvOperator, params bool[] values)
        {
            // If no values given, add not constraints and return
            if (values.Length == 0) return;

            // If only one value given, add it with no special grouping and return
            if (values.Length == 1)
            {
                query.AddConstraint(dottedAddress, wvOperator, values[0]);
                return;
            }

            // Add the first constraint and open the parenthesis
            query.AddConstraint(dottedAddress, wvOperator, values[0], Connector.OrConnector, Grouping.OpenParenthesis);

            // Add all middle constraints with an Or connector and no parenthesis
            for (int i = 1; i < values.Length - 1; i++)
            {
                query.AddConstraint(dottedAddress, wvOperator, values[i], Connector.OrConnector, Grouping.NoParenthesis);
            }

            // Add final constraint with a closing parenthesis and an And connector (design decision)
            query.AddConstraint(dottedAddress, wvOperator, values[values.Length - 1], Connector.AndConnector, Grouping.CloseParenthesis);
        }

        /// <summary>
        /// Adds a list of constraints to a filter grouped together in parenthesis and Or connectors
        /// </summary>
        /// <param name="query">The filter query the constraints should be added to</param>
        /// <param name="dottedAddress">The desired string address that constraints should be added to</param>
        /// <param name="wvOperator">The operator to be used between the address and value</param>
        /// <param name="values">The values that should be used for the grouping</param>
        public static void AddGroupedConstraints(this ModifiableFilterQuery query, string dottedAddress, Operator wvOperator, params double[] values)
        {
            // If no values given, add not constraints and return
            if (values.Length == 0) return;

            // If only one value given, add it with no special grouping and return
            if (values.Length == 1)
            {
                query.AddConstraint(dottedAddress, wvOperator, values[0]);
                return;
            }

            // Add the first constraint and open the parenthesis
            query.AddConstraint(dottedAddress, wvOperator, values[0], Connector.OrConnector, Grouping.OpenParenthesis);

            // Add all middle constraints with an Or connector and no parenthesis
            for (int i = 1; i < values.Length - 1; i++)
            {
                query.AddConstraint(dottedAddress, wvOperator, values[i], Connector.OrConnector, Grouping.NoParenthesis);
            }

            // Add final constraint with a closing parenthesis and an And connector (design decision)
            query.AddConstraint(dottedAddress, wvOperator, values[values.Length - 1], Connector.AndConnector, Grouping.CloseParenthesis);
        }
    }
}
