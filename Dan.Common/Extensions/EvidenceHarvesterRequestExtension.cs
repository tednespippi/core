﻿namespace Dan.Common.Extensions;

/// <summary>
/// Extension methods for evidence harvester requests
/// </summary>
public static class EvidenceHarvesterRequestExtension
{
    /// <summary>
    /// Tries to get the requested parameter as a string in the supplied out parameter. Returns false if not set.
    /// </summary>
    /// <param name="ehr">The evidence harvester request</param>
    /// <param name="paramName">The parameter name</param>
    /// <param name="value">The parameter value</param>
    /// <returns>True if the parameter was supplied and was valid; otherwise false</returns>
    public static bool TryGetParameter(this EvidenceHarvesterRequest ehr, string paramName, out string? value)
    {
        if (!ehr.TryGetParameter(paramName, out EvidenceParameter? parameter))
        {
            value = default;
            return false;
        }

        value = (string?)parameter?.Value;
        return true;
    }

    /// <summary>
    /// Tries to get the requested parameter as a integer in the supplied out parameter. Returns false if not set.
    /// </summary>
    /// <param name="ehr">The evidence harvester request</param>
    /// <param name="paramName">The parameter name</param>
    /// <param name="value">The parameter value</param>
    /// <returns>True if the parameter was supplied and was valid; otherwise false</returns>
    public static bool TryGetParameter(this EvidenceHarvesterRequest ehr, string paramName, out int value)
    {
        if (!ehr.TryGetParameter(paramName, out EvidenceParameter? parameter))
        {
            value = default;
            return false;
        }

        return int.TryParse((string?)parameter?.Value, out value);
    }

    /// <summary>
    /// Tries to get the requested parameter as a decimal in the supplied out parameter. Returns false if not set.
    /// </summary>
    /// <param name="ehr">The evidence harvester request</param>
    /// <param name="paramName">The parameter name</param>
    /// <param name="value">The parameter value</param>
    /// <returns>True if the parameter was supplied and was valid; otherwise false</returns>
    public static bool TryGetParameter(this EvidenceHarvesterRequest ehr, string paramName, out decimal value)
    {
        if (!ehr.TryGetParameter(paramName, out EvidenceParameter? parameter))
        {
            value = default;
            return false;
        }

        return decimal.TryParse((string?)parameter?.Value, out value);
    }

    /// <summary>
    /// Tries to get the requested parameter as a decimal in the supplied out parameter. Returns false if not set.
    /// </summary>
    /// <param name="ehr">The evidence harvester request</param>
    /// <param name="paramName">The parameter name</param>
    /// <param name="value">The parameter value</param>
    /// <returns>True if the parameter was supplied and was valid; otherwise false</returns>
    public static bool TryGetParameter(this EvidenceHarvesterRequest ehr, string paramName, out DateTime value)
    {
        if (!ehr.TryGetParameter(paramName, out EvidenceParameter? parameter))
        {
            value = default;
            return false;
        }

        return DateTime.TryParse((string?)parameter?.Value, out value);
    }


    /// <summary>
    /// Tries to get the requested parameter as a boolean in the supplied out parameter. Returns false if not set.
    /// </summary>
    /// <param name="ehr">The evidence harvester request</param>
    /// <param name="paramName">The parameter name</param>
    /// <param name="value">The parameter value</param>
    /// <returns>True if the parameter was supplied and was valid; otherwise false</returns>
    public static bool TryGetParameter(this EvidenceHarvesterRequest ehr, string paramName, out bool value)
    {
        if (!ehr.TryGetParameter(paramName, out EvidenceParameter? parameter))
        {
            value = default;
            return false;
        }

        return bool.TryParse((string?)parameter?.Value, out value);
    }

    /// <summary>
    /// Gets a parameter if set
    /// </summary>
    /// <param name="ehr">The evidence harvester request</param>
    /// <param name="paramName">The parameter name</param>
    /// <param name="parameter"></param>
    /// <returns>The parameter</returns>
    public static bool TryGetParameter(this EvidenceHarvesterRequest ehr, string paramName, out EvidenceParameter? parameter)
    {
        parameter = ehr.Parameters?.FirstOrDefault(x => x.EvidenceParamName == paramName);
        return parameter != null;
    }

    /// <summary>
    /// Gets a parameter value as the requested type if set 
    /// </summary>
    /// <remarks>This is deprecated. Use TryGetParameter instead</remarks>
    /// <typeparam name="T">The requested type to attempt to cast the value to</typeparam>
    /// <param name="ehr">The evidence harvester request</param>
    /// <param name="paramName">The parameter name</param>
    /// <returns>The parameter value</returns>
    public static T? GetParameterValue<T>(this EvidenceHarvesterRequest ehr, string paramName)
    {
        return (T?)ehr.GetParameter(paramName).Value;
    }

    /// <summary>
    /// Gets a parameter if set
    /// </summary>
    /// /// <remarks>This is deprecated. Use TryGetParameter instead</remarks>
    /// <param name="ehr">The evidence harvester request</param>
    /// <param name="paramName">The parameter name</param>
    /// <returns>The parameter</returns>
    public static EvidenceParameter GetParameter(this EvidenceHarvesterRequest ehr, string paramName)
    {
        var param = ehr.Parameters?.FirstOrDefault(x => x.EvidenceParamName == paramName);
        if (param == null)
        {
            throw new ArgumentNullException($"The parameter {paramName} was not provided");
        }

        return param;
    }
}