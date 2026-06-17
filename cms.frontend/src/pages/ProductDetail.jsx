import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import api from "../services/api";

function ProductDetail() {
    const { id } = useParams();
    const [product, setProduct] = useState(null);

    useEffect(() => {
        loadProduct();
    }, [id]);

    const loadProduct = async () => {
        const res = await api.get(`/Products/${id}`);
        setProduct(res.data);
    };

    if (product === null) {
        return <p>Đang tải...</p>;
    }

    return (
        <div className="detail">
            <img
                src={`https://localhost:7072${product.imageUrl}`}
                alt={product.name}
            />

            <h1>{product.name}</h1>

            <p>{product.description}</p>

            <h3>{Number(product.price).toLocaleString()} VNĐ</h3>

            <p>Số lượng kho: {product.stockQuantity}</p>
        </div>
    );
}

export default ProductDetail;