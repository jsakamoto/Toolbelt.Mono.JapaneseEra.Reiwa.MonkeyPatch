# Mono ランタイム用 "令和" 対応モンキーパッチ [![NuGet Package](https://img.shields.io/nuget/v/Toolbelt.Mono.JapaneseEra.Reiwa.MonkeyPatch.svg)](https://www.nuget.org/packages/Toolbelt.Mono.JapaneseEra.Reiwa.MonkeyPatch/)

## 概要

Client-side Blazor などの Mono ランタイムにおいて、`System.Globalization.JapaneseCalendar` 実装を書き換え、和暦年号 "令和" を有効にするライブラリです。

## 使い方

### Step.1 - パッケージのインストール

まずは下記要領で、本ライブラリを対象プロジェクトに追加しておきます。

dotnet CLI を使う場合:

```shell
> dotnet add package Toolbelt.Mono.JapaneseEra.Reiwa.MonkeyPatch
```

### Step.2 - モンキーパッチの適用

対象プログラムの起動時、例えば Client-side Blazor アプリケーションであれば `Startup` クラスの `Configure()` メソッド内などで、本ライブラリに収録のクラス `Toolbelt.Mono.Globalization.JapaneseEraMonkeyPatch` の `EnableReiwa()` 静的メソッドを呼び出します。

```csharp
// Client-side Blazor での実装例
// - Startup.cs
using Toolbelt.Mono.Globalization; // ← この名前空間を開いておく
...
public class Startup
{
  ...
  public void Configure(...)
  {
      JapaneseEraMonkeyPatch.EnableReiwa(); // ← これを実行!
      ...
```

以上です。

上記を実行した以降、`System.Globalization.JapaneseCalendar` を用いて日付を和暦表記に書式化する際に、年号 "令和" が有効になります (下記例)。

```csharp
var cultureInfo = new CultureInfo("ja-JP", false);
cultureInfo.DateTimeFormat.Calendar = new JapaneseCalendar();

var date = new DateTime(2019, 6, 5);
date.ToString("gy'年'M月d日", cultureInfo); // ← "令和元年6月5日" が返る
```

## 注意

本ライブラリは、Mono ランタイムにおける `System.Globalization.JapaneseCalendar` の内部実装を Reflection を経由して実行時に書き換えることで、令和対応を実現しています。

**Mono ランタイムの `System.Globalization.JapaneseCalendar` の実装変更により、本ライブラリは動作しなくなる可能性があります。**


## ライセンス

[Mozilla Public License Version 2.0](https://raw.githubusercontent.com/jsakamoto/Toolbelt.Mono.JapaneseEra.Reiwa.MonkeyPatch/master/LICENSE)
