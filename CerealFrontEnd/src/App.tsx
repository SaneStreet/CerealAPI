import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./pages/Home";
import Cereals from "./pages/Cereals";
import CerealDetail from "./pages/CerealDetail";
import Navbar from "./components/Navbar";
import CreateCereal from "./pages/CreateCereal";

export default function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/cereals" element={<Cereals />} />
        <Route path="/cereals/new" element={<CreateCereal />} />
        <Route path="/cereals/:id" element={<CerealDetail />} />
      </Routes>
    </Router>
  );
}