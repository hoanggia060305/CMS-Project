import { useEffect, useState } from "react";
import api from "../services/api";
import ProductGrid from "../components/ProductGrid";

function Shop({ keyword }) {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        loadProducts();
    }, []);

    const loadProducts = async () => {
        const res = await api.get("/Products");
        setProducts(res.data);
    };

    const filteredProducts = products.filter((item) =>
        item.name.toLowerCase().includes(keyword.toLowerCase())
    );

    return (
        <div>
            <div className="page-title">
                <h1>Trang cửa hàng</h1>
                <p>Danh sách sản phẩm đang được lấy trực tiếp từ SQL Server thông qua Web API.</p>
            </div>

            <ProductGrid products={filteredProducts} />
        </div>
    );
}

export default Shop;