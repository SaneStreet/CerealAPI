import { useState } from "react";
import type { Cereal } from "../types";

interface Props {
  initialData?: Partial<Cereal>;
  onSubmit: (data: Partial<Cereal>) => Promise<void> | void;
  submitLabel?: string;
}

export default function CerealForm({
  initialData = {},
  onSubmit,
  submitLabel = "Save",
}: Props) {
  const [formData, setFormData] = useState<Partial<Cereal>>({
    id: initialData.id ?? 0,
    name: initialData.name ?? "",
    mfr: initialData.mfr ?? "",
    type: initialData.type ?? "",
    calories: initialData.calories ?? 0,
    protein: initialData.protein ?? 0,
    fat: initialData.fat ?? 0,
    sodium: initialData.sodium ?? 0,
    fiber: initialData.fiber ?? 0,
    carbo: initialData.carbo ?? 0,
    sugars: initialData.sugars ?? 0,
    potass: initialData.potass ?? 0,
    vitamins: initialData.vitamins ?? 0,
    shelf: initialData.shelf ?? 0,
    weight: initialData.weight ?? 0,
    cups: initialData.cups ?? 0,
    rating: initialData.rating ?? 0,
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    // Tjek om feltet er numerisk
    const numericFields = [
      "id", "calories", "protein", "fat", "sodium", "fiber", "carbo",
      "sugars", "potass", "vitamins", "shelf", "weight", "cups", "rating",
    ];

    setFormData((prev) => ({
      ...prev,
      [name]: numericFields.includes(name) ? Number(value) : value,
    }));
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    await onSubmit(formData);
  };

  const fields: { name: keyof Cereal; label: string; type?: string }[] = [
    { name: "name", label: "Name" },
    { name: "mfr", label: "Manufacturer" },
    { name: "type", label: "Type" },
    { name: "calories", label: "Calories", type: "number" },
    { name: "protein", label: "Protein", type: "number" },
    { name: "fat", label: "Fat", type: "number" },
    { name: "sodium", label: "Sodium", type: "number" },
    { name: "fiber", label: "Fiber", type: "number" },
    { name: "carbo", label: "Carbohydrates", type: "number" },
    { name: "sugars", label: "Sugars", type: "number" },
    { name: "potass", label: "Potassium", type: "number" },
    { name: "vitamins", label: "Vitamins", type: "number" },
    { name: "shelf", label: "Shelf", type: "number" },
    { name: "weight", label: "Weight", type: "number" },
    { name: "cups", label: "Cups", type: "number" },
    { name: "rating", label: "Rating", type: "number" },
  ];

  return (
    <form onSubmit={handleSubmit} className="grid grid-cols-1 md:grid-cols-2 gap-4">
      {fields.map((f) => (
        <div key={f.name}>
          <label className="block mb-1 font-medium">{f.label}:</label>
          <input
            name={f.name}
            type={f.type || "text"}
            value={formData[f.name] ?? ""}
            onChange={handleChange}
            className="border px-3 py-2 w-full rounded"
            required={f.name === "name"}
          />
        </div>
      ))}

      <div className="md:col-span-2 flex justify-end mt-4">
        <button
          type="submit"
          className="bg-blue-600 text-white px-6 py-2 rounded hover:bg-blue-700"
        >
          {submitLabel}
        </button>
      </div>
    </form>
  );
}
