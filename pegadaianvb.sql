-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 16 Apr 2020 pada 07.04
-- Versi server: 10.3.16-MariaDB
-- Versi PHP: 7.3.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pegadaianvb`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `barang`
--

CREATE TABLE `barang` (
  `Kodebarang` varchar(11) NOT NULL,
  `Namabarang` varchar(45) DEFAULT NULL,
  `Type` varchar(45) DEFAULT NULL,
  `Warna` varchar(45) DEFAULT NULL,
  `status` enum('Tersedia','Tergadai','Sudah Ditebus','Milik Pegadaian') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Struktur dari tabel `nasabah`
--

CREATE TABLE `nasabah` (
  `Ktp` varchar(16) NOT NULL,
  `Nama` varchar(45) DEFAULT NULL,
  `Alamat` varchar(45) DEFAULT NULL,
  `Hp` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Struktur dari tabel `petugas`
--

CREATE TABLE `petugas` (
  `Nip` varchar(11) NOT NULL,
  `Namapetugas` varchar(45) DEFAULT NULL,
  `alamat` varchar(45) DEFAULT NULL,
  `username` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `Hakakses` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `petugas`
--

INSERT INTO `petugas` (`Nip`, `Namapetugas`, `alamat`, `username`, `Password`, `Hakakses`) VALUES
('P0001', 'ARSIDIN', '-', 'ARSIDIN', '001002', 'Admin');

-- --------------------------------------------------------

--
-- Struktur dari tabel `transaksi`
--

CREATE TABLE `transaksi` (
  `No_transaksi` varchar(11) NOT NULL,
  `Tgl_gadai` date DEFAULT NULL,
  `Jatuh_tempo` date DEFAULT NULL,
  `Jumlah_pinjaman` double DEFAULT NULL,
  `Tgl_tebusan` date DEFAULT NULL,
  `Jumlah_tebusan` double DEFAULT NULL,
  `denda` double DEFAULT NULL,
  `Bunga` double DEFAULT NULL,
  `total_tebusan` double DEFAULT NULL,
  `Keterangan` varchar(45) DEFAULT NULL,
  `Barang_Kode_barang` varchar(11) NOT NULL,
  `Petugas_Nip` varchar(11) NOT NULL,
  `Nasabah_Ktp` varchar(16) NOT NULL,
  `bayar` int(11) DEFAULT NULL,
  `kembalian` int(11) DEFAULT NULL,
  `perjanjian` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `barang`
--
ALTER TABLE `barang`
  ADD PRIMARY KEY (`Kodebarang`);

--
-- Indeks untuk tabel `nasabah`
--
ALTER TABLE `nasabah`
  ADD PRIMARY KEY (`Ktp`);

--
-- Indeks untuk tabel `petugas`
--
ALTER TABLE `petugas`
  ADD PRIMARY KEY (`Nip`);

--
-- Indeks untuk tabel `transaksi`
--
ALTER TABLE `transaksi`
  ADD PRIMARY KEY (`No_transaksi`),
  ADD KEY `Nasabah_Ktp` (`Nasabah_Ktp`),
  ADD KEY `Barang_Kode_barang` (`Barang_Kode_barang`),
  ADD KEY `Petugas_Nip` (`Petugas_Nip`);

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `transaksi`
--
ALTER TABLE `transaksi`
  ADD CONSTRAINT `transaksi_ibfk_1` FOREIGN KEY (`Nasabah_Ktp`) REFERENCES `nasabah` (`Ktp`),
  ADD CONSTRAINT `transaksi_ibfk_2` FOREIGN KEY (`Barang_Kode_barang`) REFERENCES `barang` (`Kodebarang`),
  ADD CONSTRAINT `transaksi_ibfk_3` FOREIGN KEY (`Petugas_Nip`) REFERENCES `petugas` (`Nip`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
