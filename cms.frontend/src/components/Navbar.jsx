import { Link } from "react-router-dom";

function Navbar({ keyword, setKeyword }) {
    return (
        <nav className="navbar">
            <Link to="/" className="logo">GiaCMS Shop</Link>

            <div className="nav-links">
                <Link to="/">Trang chủ</Link>
                <Link to="/shop">Cửa hàng</Link>
            </div>

            <input
                className="search-box"
                type="text"
                placeholder="Tìm sản phẩm..."
                value={keyword}
                onChange={(e) => setKeyword(e.target.value)}
            />
        </nav>
    );
}

export default Navbar;