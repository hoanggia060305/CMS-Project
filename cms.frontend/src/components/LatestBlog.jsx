function LatestBlog({ posts }) {
    return (
        <div>
            <h2>Bài viết mới nhất</h2>

            <div className="blog-grid">
                {posts.map((item) => (
                    <div className="card" key={item.id}>
                        <img
                            src={`https://localhost:7072${item.imageUrl}`}
                            alt={item.title}
                        />

                        <h3>{item.title}</h3>

                        <p>{item.content}</p>
                    </div>
                ))}
            </div>
        </div>
    );
}

export default LatestBlog;