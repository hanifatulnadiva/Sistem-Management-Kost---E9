CREATE TABLE penyewa (
    NIK CHAR(16) PRIMARY KEY, --
    nama VARCHAR(100) NOT NULL,
    kontak VARCHAR(13) NOT NULL CHECK (kontak LIKE '[0-9]%'), 
    tanggal_masuk DATE NOT NULL
);

CREATE TABLE kamar (
    id_kamar CHAR(5) PRIMARY KEY, 
    harga DECIMAL(10,2) NOT NULL,
    status VARCHAR(10) CHECK (status IN ('tersedia', 'disewa')),
    NIK CHAR(16) NULL, 
    FOREIGN KEY (NIK) REFERENCES penyewa(NIK) ON DELETE SET NULL
);

CREATE TABLE pembayaran (
    id_pembayaran CHAR(5) PRIMARY KEY, 
    NIK CHAR(16) NOT NULL,
    tanggal_pembayaran DATE NOT NULL,
    jumlah DECIMAL(10,2) NOT NULL,
    metode_pembayaran VARCHAR(8) CHECK (metode_pembayaran IN ('transfer', 'tunai')),
    FOREIGN KEY (NIK) REFERENCES penyewa(NIK) ON DELETE CASCADE
);

CREATE TABLE pemeliharaan (
    id_pemeliharaan CHAR(5) PRIMARY KEY, 
    id_kamar CHAR(5) NOT NULL,
    deskripsi VARCHAR(200) NOT NULL,
    tanggal DATE NOT NULL,
    biaya DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (id_kamar) REFERENCES kamar(id_kamar) ON DELETE CASCADE
);
