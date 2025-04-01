# NFT Generator

Advanced metadata generation system for NFT collections with configurable trait rarities, uniqueness enforcement, and relict item support. The system supports weighted randomization with configurable uniqueness thresholds to prevent duplicates or near-duplicates.

## Features

- Trait-based NFT metadata generation with JSON output
- Configurable rarity tiers
- Weighted randomization based on rarity distributions
- Dynamic uniqueness thresholds that scale with iteration count
- Special "Relict" NFT support with guaranteed placement
- Material interaction rules (e.g., material combinations and constraints)
- Multi-creator royalty attribution with configurable shares
- Performance monitoring with real-time statistics

## Technical Implementation

- Written in C# using Windows Forms
- Metadata generated in Metaplex-compatible JSON format
- Randomization using configurable seed values
- Parallel task execution with async/await pattern
- Reflection-based attribute handling for flexible trait schema

## Usage

1. Configure trait pools and rarity tables
2. Set collection size and randomization seed
3. Run generation process
4. JSON files are output to the configured directory