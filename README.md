# Mono �����^�C���p "�ߘa" �Ή������L�[�p�b�` [![NuGet Package](https://img.shields.io/nuget/v/Toolbelt.Mono.JapaneseEra.Reiwa.MonkeyPatch.svg)](https://www.nuget.org/packages/Toolbelt.Mono.JapaneseEra.Reiwa.MonkeyPatch/)

## �T�v

Client-side Blazor �Ȃǂ� Mono �����^�C���ɂ����āA`System.Globalization.JapaneseCalendar` ���������������A�a��N�� "�ߘa" ��L���ɂ��郉�C�u�����ł��B

## �g����

### Step.1 - �p�b�P�[�W�̃C���X�g�[��

�܂��͉��L�v�̂ŁA�{���C�u������Ώۃv���W�F�N�g�ɒǉ����Ă����܂��B

dotnet CLI ���g���ꍇ:

```shell
> dotnet add package Toolbelt.Mono.JapaneseEra.Reiwa.MonkeyPatch
```

### Step.2 - �����L�[�p�b�`�̓K�p

�Ώۃv���O�����̋N�����A�Ⴆ�� Client-side Blazor �A�v���P�[�V�����ł���� `Startup` �N���X�� `Configure()` ���\�b�h���ȂǂŁA�{���C�u�����Ɏ��^�̃N���X `Toolbelt.Mono.Globalization.JapaneseEraMonkeyPatch` �� `EnableReiwa()` �ÓI���\�b�h���Ăяo���܂��B

```csharp
// Client-side Blazor �ł̎�����
// - Startup.cs
using Toolbelt.Mono.Globalization; // �� ���̖��O��Ԃ��J���Ă���
...
public class Startup
{
  ...
  public void Configure(...)
  {
      JapaneseEraMonkeyPatch.EnableReiwa(); // �� ��������s!
      ...
```

�ȏ�ł��B

��L�����s�����ȍ~�A`System.Globalization.JapaneseCalendar` ��p���ē��t��a��\�L�ɏ���������ۂɁA�N�� "�ߘa" ���L���ɂȂ�܂� (���L��)�B

```csharp
var cultureInfo = new CultureInfo("ja-JP", false);
cultureInfo.DateTimeFormat.Calendar = new JapaneseCalendar();

var date = new DateTime(2019, 6, 5);
date.ToString("gy'�N'M��d��", cultureInfo); // �� "�ߘa���N6��5��" ���Ԃ�
```

## ����

�{���C�u�����́AMono �����^�C���ɂ����� `System.Globalization.JapaneseCalendar` �̓��������� Reflection ���o�R���Ď��s���ɏ��������邱�ƂŁA�ߘa�Ή����������Ă��܂��B

**Mono �����^�C���� `System.Globalization.JapaneseCalendar` �̎����ύX�ɂ��A�{���C�u�����͓��삵�Ȃ��Ȃ�\��������܂��B**


## ���C�Z���X

[Mozilla Public License Version 2.0](https://raw.githubusercontent.com/jsakamoto/Toolbelt.Mono.JapaneseEra.Reiwa.MonkeyPatch/master/LICENSE)
