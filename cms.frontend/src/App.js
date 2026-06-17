import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useState } from "react";

import Navbar from "./components/Navbar";
import Footer from "./components/Footer";
import Home from "./pages/Home";
import Shop from "./pages/Shop";
import ProductDetail from "./pages/ProductDetail";

import "./App.css";

function App() {
    const [keyword, setKeyword] = useState("");

    return (
        <BrowserRouter>
            <Navbar keyword={keyword} setKeyword={setKeyword} />

            <main className="main-content">
                <Routes>
                    <Route path="/" element={<Home keyword={keyword} />} />
                    <Route path="/shop" element={<Shop keyword={keyword} />} />
                    <Route path="/product/:id" element={<ProductDetail />} />
                </Routes>
            </main>

            <Footer />
        </BrowserRouter>
    );
}

export default App;