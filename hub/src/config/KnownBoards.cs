﻿using System.Windows.Media.Media3D;

static class KnownBoard {
    public static readonly BoardDescription Aldo = new BoardDescription(
        "Qubit Aldo HC-06",
        "98 D3 33 80 5C D2",
        "7065",
        new Quaternion(new Vector3D(1, 1, 1), -120));

    public static readonly BoardDescription Boni = new BoardDescription(
        "Boni",
        "98 D3 31 FC 11 52",
        "deep birch wire",
        new Quaternion(new Vector3D(1, 1, 1), -120));

    public static readonly BoardDescription Colu = new BoardDescription(
        "Colu",
        "98 D3 31 FB 18 8A",
        "barge clog many",
        new Quaternion(new Vector3D(1, 1, 1), -120));

    public static readonly BoardDescription Dask = new BoardDescription(
        "Qubit Dask HC-06",
        "98 D3 34 90 53 9D",
        "7763",
        new Quaternion(new Vector3D(1, 1, 1), -120));

    public static readonly BoardDescription Elto = new BoardDescription(
        "Qubit Elto HC-06",
        "98 D3 32 70 53 BC",
        "0243",
        new Quaternion(new Vector3D(1, 1, 1), -120));
}
