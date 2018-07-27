﻿// Copyright (c) Six Labors and contributors.
// Licensed under the Apache License, Version 2.0.

using System;

namespace SixLabors.ImageSharp.ColorSpaces.Conversion.Implementation
{
    /// <summary>
    /// Trivial implementation of <see cref="RgbWorkingSpace"/>
    /// </summary>
    public class RgbWorkingSpace : IEquatable<RgbWorkingSpace>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RgbWorkingSpace"/> class.
        /// </summary>
        /// <param name="referenceWhite">The reference white point.</param>
        /// <param name="companding">The function pair for converting to <see cref="CieXyz"/> and back.</param>
        /// <param name="chromaticityCoordinates">The chromaticity of the rgb primaries.</param>
        public RgbWorkingSpace(CieXyz referenceWhite, ICompanding companding, RgbPrimariesChromaticityCoordinates chromaticityCoordinates)
        {
            this.WhitePoint = referenceWhite;
            this.Companding = companding;
            this.ChromaticityCoordinates = chromaticityCoordinates;
        }

        /// <summary>
        /// Gets the reference white point
        /// </summary>
        public CieXyz WhitePoint { get; }

        /// <summary>
        /// Gets the function pair for converting to <see cref="CieXyz"/> and back.
        /// </summary>
        public ICompanding Companding { get; }

        /// <summary>
        /// Gets the chromaticity of the rgb primaries.
        /// </summary>
        public RgbPrimariesChromaticityCoordinates ChromaticityCoordinates { get; }

        /// <summary>
        /// Compares two <see cref="RgbWorkingSpace"/> objects for equality.
        /// </summary>
        /// <param name="left">The <see cref="RgbWorkingSpace"/> on the left side of the operand.</param>
        /// <param name="right">The <see cref="RgbWorkingSpace"/> on the right side of the operand.</param>
        /// <returns>
        /// True if the current left is equal to the <paramref name="right"/> parameter; otherwise, false.
        /// </returns>
        public static bool operator ==(RgbWorkingSpace left, RgbWorkingSpace right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Compares two <see cref="RgbWorkingSpace"/> objects for inequality
        /// </summary>
        /// <param name="left">The <see cref="RgbWorkingSpace"/> on the left side of the operand.</param>
        /// <param name="right">The <see cref="RgbWorkingSpace"/> on the right side of the operand.</param>
        /// <returns>
        /// True if the current left is unequal to the <paramref name="right"/> parameter; otherwise, false.
        /// </returns>
        public static bool operator !=(RgbWorkingSpace left, RgbWorkingSpace right)
        {
            return !Equals(left, right);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is RgbWorkingSpace other && this.Equals(other);
        }

        /// <inheritdoc/>
        public bool Equals(RgbWorkingSpace other)
        {
            // TODO: Object.Equals for ICompanding will be slow.
            return this.WhitePoint.Equals(other.WhitePoint)
                && this.ChromaticityCoordinates.Equals(other.ChromaticityCoordinates)
                && Equals(this.Companding, other.Companding);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int hash = this.WhitePoint.GetHashCode();
            hash = HashHelpers.Combine(hash, this.ChromaticityCoordinates.GetHashCode());
            hash = HashHelpers.Combine(hash, this.Companding?.GetHashCode() ?? 0);
            return hash;
        }
    }
}