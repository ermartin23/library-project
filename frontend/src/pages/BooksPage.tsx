export default function BooksPage() {
    return (
        <div className="min-h-screen bg-base-100 flex flex-col items-center justify-center font-opensans">
            {/* Header */}
            <div className="flex flex-col items-center gap-2 mb-6">
                <div className="flex items-center gap-3">
                    <img src="/vite.svg" alt="logo" className="w-10 h-10" />
                    <h1 className="text-4xl font-bold">Library Books</h1>
                </div>
                <h2 className="text-xl font-semibold text-gray-600">
                    Choose one of the following options
                </h2>
            </div>

            {/* Buttons */}
            <div className="flex gap-4 mt-6">
                <button className="btn btn-primary">Add</button>
                <button className="btn btn-error">Delete</button> {/* red */}
                <button className="btn btn-success">See Author</button> {/* green */}
            </div>
        </div>
    );
}
