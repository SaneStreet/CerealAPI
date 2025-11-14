import { Link } from "react-router-dom";

export default function Navbar() {
  return (
    <nav className="bg-gray-800 text-white px-6 py-3 flex justify-between items-center">
      <h1 className="text-lg font-bold"><Link to="/" className="text-white!"> 🌾 Cereal API</Link></h1>
      <div className="flex gap-4">
        <Link to="/" className="hover:underline text-white!">🛖 Home</Link>
        <Link to="/cereals" className="hover:underline text-white!"> 📜 Cereals</Link>
        <Link to="/cereals/new" className="hover:underline text-white!"> 🖋️ Create</Link>
      </div>
    </nav>
  );
}