interface Props {
  search: string;
  setSearch: (v: string) => void;
}

export default function CerealFilter({ search, setSearch }: Props) {
  return (
    <input
      type="text"
      value={search}
      onChange={(e) => setSearch(e.target.value)}
      placeholder="Søg efter navn..."
      className="border rounded px-3 py-2 w-full mb-4"
    />
  );
}