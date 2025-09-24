import { useEffect, useState } from "react";

function AuthorList() {
    const [authors, setAuthors] = useState([]);

    useEffect(() => {
        fetch("http://localhost:5084/api/Author") // 👈 tu backend
            .then((response) => response.json())
            .then((data) => setAuthors(data))
            .catch((error) => console.error("Error fetching authors:", error));
    }, []);

    return (
        <div className="p-6">
            <h2 className="text-xl font-bold mb-4">📚 Authors</h2>
            <table className="table-auto border-collapse border border-gray-400 w-full">
                <thead>
                <tr className="bg-gray-200">
                    <th className="border border-gray-400 px-4 py-2">ID</th>
                    <th className="border border-gray-400 px-4 py-2">Name</th>
                </tr>
                </thead>
                <tbody>
                {authors.map((a) => (
                    <tr key={a.id}>
                        <td className="border border-gray-400 px-4 py-2">{a.id}</td>
                        <td className="border border-gray-400 px-4 py-2">{a.name}</td>
                    </tr>
                ))}
                </tbody>
            </table>
        </div>
    );
}

export default AuthorList;
