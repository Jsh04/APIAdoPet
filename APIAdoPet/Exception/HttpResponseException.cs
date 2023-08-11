﻿using Microsoft.AspNetCore.Http;

namespace APIAdoPet.Exception;

public class HttpResponseException : System.Exception
{
    public int StatusCode { get; }

    public object? Value { get; }

    public HttpResponseException(int statusCode, object? value = null) =>
    (StatusCode, Value) = (statusCode, value);
}
