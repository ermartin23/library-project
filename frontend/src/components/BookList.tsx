export default function BookList() {
    return (
        <div className="card bg-base-200 shadow-xl p-6">
            <h2 className="card-title mb-4">📚 Book List</h2>
            <ul className="list-disc pl-5">
                <li>The Hobbit – J.R.R. Tolkien</li>
                <li>1984 – George Orwell</li>
                <li>Clean Code – Robert C. Martin</li>
            </ul>
            <div className="card-actions justify-end mt-4">
                <button className="btn btn-primary">Add</button>
                <button className="btn btn-secondary">Delete</button>
                <button className="btn btn-accent">Author</button>
            </div>
        </div>
    )
}
