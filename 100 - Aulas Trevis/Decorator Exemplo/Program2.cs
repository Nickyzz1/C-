var ep1 = cors(jwt(new ProductEndPoint()));
var ep2 = cors(new ProductEndPoint());
var ep3 = jwt(new ProductEndPoint());
var ep4 = new ProductEndPoint();

var products = ep1.Call(new {
    Price = 4f,
    Jwt = "um.jwt.valido"
});

EndPoint<T> cors<T>(EndPoint<T> ep)
    => new CORSConfigs<T>(ep);

EndPoint<T> jwt<T>(EndPoint<T> ep)
    => new JWTValidator<T>(ep);

public abstract class EndPoint<T>
{
    public abstract T Call(object arguments);
}

public record Product;

public class ProductEndPoint : EndPoint<List<Product>>
{
    public override List<Product> Call(object arguments)
    {
        // faz uma busca
        return [ new Product(), new Product(), new Product() ];
    }
}

public class JWTValidator<T>(EndPoint<T> inner) : EndPoint<T>
{
    public readonly EndPoint<T> Inner = inner;

    public override T Call(object arguments)
    {
        // Valida Jwt ou lança excessão
        return Inner.Call(arguments);
    }
}

public class CORSConfigs<T>(EndPoint<T> inner) : EndPoint<T>
{
    public override T Call(object arguments)
    {
        // valida CORS
        return inner.Call(arguments);
    }
}