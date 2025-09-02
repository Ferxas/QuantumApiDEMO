namespace Demo {
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Measurement;

    operation RandomBit() : Result {
        use q = Qubit();
        H(q);
        let r = M(q);
        Reset(q);
        return r;
    }

    operation FlipAndMeasure(theta : Double) : Result {
        use q = Qubit();
        Ry(theta, q);
        let r = M(q);
        Reset(q);
        return r;
    }
}