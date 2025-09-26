import { useState } from "react";
import AuthorList from "./components/AuthorList";
import AuthorForm from "./components/AuthorForm";

function App() {
    const [reload, setReload] = useState(false);

    return (
        <div className="min-h-screen bg-gray-50 flex flex-col items-center justify-center">
            <h1 className="text-2xl font-bold mb-6">Library Project 📖</h1>

            <AuthorForm onAuthorAdded={() => setReload(!reload)} />
            <AuthorList key={reload} />
        </div>
    );
}

export default App;
