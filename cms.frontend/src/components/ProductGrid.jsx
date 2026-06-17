import { Link } from "react-router-dom";

function ProductGrid({ products }) {
    return (
        <div>
            <h2>Sản phẩm</h2>

            <div className="product-grid">
                {products.map((item) => (
                    <div className="card" key={item.id}>
                        <img
                            src={`https://localhost:7072${item.imageUrl}`}
                            alt={item.name}
                        />

                        <h3>{item.name}</h3>

                        <p className="price">
                            {Number(item.price).toLocaleString()} VNĐ
                        </p>

                        <Link to={`/product/${item.id}`}>
                            Xem chi tiết
                        </Link>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default ProductGrid;