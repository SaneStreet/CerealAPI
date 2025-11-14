import { useEffect, useState } from "react";
import { getCereals } from "../api/cereals";
import type { Cereal } from "../types";
import CerealTable from "../components/CerealTable";
import CerealFilter from "../components/CerealFilter";

export default function Cereals() {
  const [cereals, setCereals] = useState<Cereal[]>([]);
  const [search, setSearch] = useState("");

  useEffect(() => {
    getCereals().then(setCereals);
  }, []);

  const filtered = cereals.filter(c =>
    c.name.toLowerCase().includes(search.toLowerCase())
  );

  return (
    <div className="p-8">
      <h2 className="text-2xl font-bold mb-4">All Cereals</h2>
      <CerealFilter search={search} setSearch={setSearch} />
      <CerealTable cereals={filtered} />
    </div>
  );
}