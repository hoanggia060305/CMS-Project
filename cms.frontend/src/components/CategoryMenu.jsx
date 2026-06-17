function CategoryMenu({ categories, onSelectCategory }) {
    return (
        <div className="category-menu">
            <button onClick={() => onSelectCategory(null)}>
                Tất cả
            </button>

            {categories.map((item) => (
                <button key={item.id} onClick={() => onSelectCategory(item.id)}>
                    {item.name}
                </button>
            ))}
        </div>
    );
}

export default CategoryMenu;