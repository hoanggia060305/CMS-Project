import { useEffect, useState } from "react";
import api from "../services/api";
import CategoryMenu from "../components/CategoryMenu";
import ProductGrid from "../components/ProductGrid";
import LatestBlog from "../components/LatestBlog";

function Home({ keyword }) {
    const [categories, setCategories] = useState([]);
    const [products, setProducts] = useState([]);
    const [posts, setPosts] = useState([]);

    useEffect(() => {
        loadCategories();
        loadProducts();
        loadPosts();
    }, []);

    const loadCategories = async () => {
        const res = await api.get("/CategoriesProducts");
        setCategories(res.data);
    };

    const loadProducts = async () => {
        const res = await api.get("/Products");
        setProducts(res.data);
    };

    const loadPosts = async () => {
        const res = await api.get("/Posts");
        setPosts(res.data);
    };

    const handleSelectCategory = async (categoryId) => {
        if (categoryId === null) {
            loadProducts();
        } else {
            const res = await api.get(`/Products/category/${categoryId}`);
            setProducts(res.data);
        }
    };

    const filteredProducts = products.filter((item) =>
        item.name.toLowerCase().includes(keyword.toLowerCase())
    );

    return (
        <div>
            <div className="hero">
                <h1>GiaCMS Shop</h1>
                <p>Website bán hàng thời trang dùng ReactJS và ASP.NET Core Web API</p>
            </div>

            <CategoryMenu
                categories={categories}
                onSelectCategory={handleSelectCategory}
            />

            <ProductGrid products={filteredProducts} />

            <LatestBlog posts={posts} />
        </div>
    );
}

export default Home;