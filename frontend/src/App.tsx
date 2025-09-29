export default function App() {
    return (
        <div className="min-h-screen bg-base-200 flex flex-col items-center justify-center gap-6">
            <h1 className="text-4xl font-bold font-opensans">📚 Library Books</h1>
            <div className="flex gap-4">
                <button className="btn btn-primary">Add</button>
                <button className="btn btn-error">Delete</button>
                <button className="btn btn-secondary">See Author</button>
            </div>
        </div>
    )
}
