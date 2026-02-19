alert("home.js loaded successfully");

const staticProblems = {
    plumbing: [
        { icon: "🚰", name: "Tap Leakage" },
        { icon: "🧱", name: "Pipe Repair" },
        { icon: "🚿", name: "Bathroom Fitting" },
        { icon: "🚽", name: "Toilet Blockage" }
    ],
    electrician: [
        { icon: "💡", name: "Light Issue" },
        { icon: "🔌", name: "Socket Repair" },
        { icon: "⚡", name: "Short Circuit" }
    ],
    ac: [
        { icon: "❄", name: "AC Not Cooling" },
        { icon: "🛠", name: "Gas Refill" },
        { icon: "🔧", name: "General Service" }
    ]
};

function showProblems(service) {
    const list = document.getElementById("problemList");
    const section = document.getElementById("problemSection");

    list.innerHTML = "";

    staticProblems[service].forEach(p => {
        list.innerHTML += `
    <div class="col-6 col-md-3">
      <div class="card service-card p-3 text-center">
        <div class="icon">${p.icon}</div>
        <h6>${p.name}</h6>
      </div>
    </div>`;
    });

    section.classList.remove("d-none");
    section.scrollIntoView({ behavior: "smooth" });
}