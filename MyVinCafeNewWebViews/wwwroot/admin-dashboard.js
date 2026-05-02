
// Mock Data sesuai model yang diberikan
let employees = [
    { UserName: "rin_shima", Password: "123", Email: "rin@cafe.com", Phone: "0812345678", Role: "Admin", Employee: true },
    { UserName: "nadeshiko_k", Password: "123", Email: "nadeshiko@cafe.com", Phone: "0819998887", Role: "Barista", Employee: true },
    { UserName: "chiaki_o", Password: "123", Email: "chiaki@cafe.com", Phone: "0811122233", Role: "Manager", Employee: true }
];

let employeeModal;

window.onload = function () {
    employeeModal = new bootstrap.Modal(document.getElementById('employeeModal'));
    renderEmployees();
    updateStats();
};

// --- Auth Logic ---
function toggleAuth(target) {
    document.getElementById('login-section').style.display = target === 'login' ? 'block' : 'none';
    document.getElementById('register-section').style.display = target === 'register' ? 'block' : 'none';
}

function doLogin() {
    const username = document.getElementById('loginUsername').value;
    // Di sistem sungguhan, lakukan AJAX call dengan LoginUser DTO ke backend C#

    // Sembunyikan layar auth, munculkan app
    document.getElementById('auth-container').style.display = 'none';
    document.getElementById('app-container').style.display = 'block';

    // Update UI teks sapaan Admin
    document.getElementById('greeting-text').innerHTML = `Halo, Admin ${username}! <i class="fas fa-mug-hot text-brown"></i>`;

    showToast(`Selamat datang, ${username}!`, "success");
}

function doRegister() {
    const username = document.getElementById('regUsername').value;
    // Di sistem sungguhan, lakukan AJAX call dengan RegisterUser DTO ke backend C#
    // Properti Role = "Member" dan Employee = false dihandle oleh Backend

    showToast(`Registrasi akun ${username} berhasil! Silakan login.`, "success");

    // Pindah form ke login
    toggleAuth('login');

    // Otomatis isikan username
    document.getElementById('loginUsername').value = username;
    document.getElementById('registerForm').reset();
}

function doLogout() {
    // Sembunyikan app, munculkan layar auth
    document.getElementById('app-container').style.display = 'none';
    document.getElementById('auth-container').style.display = 'flex';

    // Reset form login & ke halaman login pertama
    document.getElementById('loginForm').reset();
    toggleAuth('login');

    showToast("Anda telah keluar dari sistem.", "info");
}

// --- Navigation Logic ---
function showPage(pageId) {
    // Sembunyikan semua halaman yang memiliki class 'page-section'
    const pages = document.querySelectorAll('.page-section');
    pages.forEach(page => page.style.display = 'none');

    // Tampilkan halaman yang dipilih jika elemennya ada
    const targetPage = document.getElementById('page-' + pageId);
    if (targetPage) {
        targetPage.style.display = 'block';
    }

    // Update active state di nav
    const navLinks = document.querySelectorAll('.nav-link');
    navLinks.forEach(link => {
        link.classList.remove('active');
        const onclickAttr = link.getAttribute('onclick');
        // Tambahkan pengecekan spesifik dengan tanda kutip untuk mencegah duplikasi nama
        if (onclickAttr && onclickAttr.includes(`'${pageId}'`)) {
            link.classList.add('active');
        }
    });
}

// --- CRUD Logic ---
function renderEmployees() {
    const tbody = document.getElementById('employee-table-body');
    tbody.innerHTML = '';

    employees.forEach((emp, index) => {
        const tr = document.createElement('tr');
        tr.innerHTML = `
    <td class="fw-bold text-primary">${emp.UserName}</td>
    <td>${emp.Email}</td>
    <td>${emp.Phone}</td>
    <td><span class="badge bg-info text-dark rounded-pill">${emp.Role}</span></td>
    <td>
        ${emp.Employee
                ? '<span class="text-success"><i class="fas fa-check-circle"></i> Aktif</span>'
                : '<span class="text-danger"><i class="fas fa-times-circle"></i> Non-Aktif</span>'}
    </td>
    <td>
        <button class="btn btn-sm btn-outline-primary me-1" onclick="editEmployee(${index})">
            <i class="fas fa-edit"></i>
        </button>
        <button class="btn btn-sm btn-outline-danger" onclick="deleteEmployee(${index})">
            <i class="fas fa-trash"></i>
        </button>
    </td>
    `;
        tbody.appendChild(tr);
    });
    updateStats();
}

function updateStats() {
    document.getElementById('count-employees').innerText = employees.length;
}

function openEmployeeModal() {
    document.getElementById('modalTitle').innerText = "Tambah Karyawan Baru";
    document.getElementById('editIndex').value = "-1";
    document.getElementById('employeeForm').reset();
    employeeModal.show();
}

function saveEmployee() {
    const index = parseInt(document.getElementById('editIndex').value);

    const newEmp = {
        UserName: document.getElementById('inpUserName').value,
        Password: document.getElementById('inpPassword').value,
        Email: document.getElementById('inpEmail').value,
        Phone: document.getElementById('inpPhone').value,
        Role: document.getElementById('inpRole').value,
        Employee: document.getElementById('inpIsEmployee').checked
    };

    // Validasi Sederhana
    if (!newEmp.UserName || !newEmp.Email || !newEmp.Phone) {
        showToast("Mohon isi semua field yang diperlukan!", "danger");
        return;
    }

    if (index === -1) {
        // Add new
        employees.push(newEmp);
        showToast("Karyawan baru berhasil ditambahkan!", "success");
    } else {
        // Update
        employees[index] = newEmp;
        showToast("Data karyawan berhasil diperbarui!", "info");
    }

    employeeModal.hide();
    renderEmployees();
}

function editEmployee(index) {
    const emp = employees[index];
    document.getElementById('modalTitle').innerText = "Edit Karyawan";
    document.getElementById('editIndex').value = index;

    document.getElementById('inpUserName').value = emp.UserName;
    document.getElementById('inpPassword').value = emp.Password;
    document.getElementById('inpEmail').value = emp.Email;
    document.getElementById('inpPhone').value = emp.Phone;
    document.getElementById('inpRole').value = emp.Role;
    document.getElementById('inpIsEmployee').checked = emp.Employee;

    employeeModal.show();
}

function deleteEmployee(index) {
    if (confirm("Apakah Anda yakin ingin menghapus " + employees[index].UserName + "?")) {
        employees.splice(index, 1);
        renderEmployees();
        showToast("Karyawan telah dihapus.", "warning");
    }
}

// Custom Notification (Toast)
function showToast(msg, type) {
    const container = document.getElementById('toastContainer');
    const toast = document.createElement('div');
    toast.className = `toast align-items-center text-white bg-${type} border-0 show m-2`;
    toast.setAttribute('role', 'alert');
    toast.innerHTML = `
    <div class="d-flex">
        <div class="toast-body">${msg}</div>
        <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast"></button>
    </div>
    `;
    container.appendChild(toast);
    setTimeout(() => toast.remove(), 3000);
}