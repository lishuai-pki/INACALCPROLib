#include <iostream>
#include <objbase.h>
#include <atlstr.h>

#include "stdafx.h"

//#import "..\INACALCPROLib\bin\Debug\INACALCPROLib.tlb"


using namespace ATL;
using namespace std;
//using namespace INACALCPROLib;

extern const TCHAR g_cstrAnd[] = _T("And");
extern const TCHAR g_cstrOr[] = _T("Or");
extern const TCHAR g_cstrNot[] = _T("Not");
extern const TCHAR g_cstrIf[] = _T("logical");
extern const TCHAR g_typeBSTR[] = _T("VT_BSTR");
extern const TCHAR g_typeEMPTY[] = _T("VT_EMPTY");
extern const TCHAR g_typeDATE[] = _T("VT_DATE");
extern const TCHAR g_typeR8[] = _T("VT_R8");
extern const TCHAR g_typeBOOL[] = _T("VT_BOOL");
static const TCHAR g_cstrExt[] = _T("_!?!");
static const TCHAR g_szEqID[] = { _T("{0FCCC1AA-41F0-4ED3-BEA0-A6D61410B645}") };
extern const TCHAR g_cstrBetween[] = _T(" Between ");
extern const TCHAR g_cstrNotBetween[] = _T(" Not Between ");


ATL::CComModule _Module;

class CMSEquation :
	//public IDispEventImpl< 1, CMSEquation, &__uuidof(_IInaCalcProEvents), &LIBID_INACALCPROLib, 2, 1>
	public IDispEventImpl< 1, CMSEquation, &__uuidof(_IInaCalcProEvents), &LIBID_INACALCPROLib, 2, 1>
{
public:
	STDMETHOD(CheckAtom)(BSTR strAtom, EInaValueType* valType);
	STDMETHOD(GetAtomValue)(BSTR strAtom, VARIANT* vntValue);
	STDMETHOD(ValueChanged)(BSTR strAtom);
	STDMETHOD(CheckCustomFunction)(BSTR strFunc, IDispatch* argTypes, EInaValueType* valType);
	STDMETHOD(EvalCustomFunction)(BSTR strFunc, IDispatch* argVals, VARIANT* vntValue);
	//STDMETHOD(AtomChanged)(IInaCalcAtom pAtom);

	BEGIN_SINK_MAP(CMSEquation)
		SINK_ENTRY_EX(1, (__uuidof(_IInaCalcProEvents)), 1, CheckAtom)
		SINK_ENTRY_EX(1, (__uuidof(_IInaCalcProEvents)), 2, GetAtomValue)
		SINK_ENTRY_EX(1, (__uuidof(_IInaCalcProEvents)), 3, ValueChanged)
		SINK_ENTRY_EX(1, (__uuidof(_IInaCalcProEvents)), 4, CheckCustomFunction)
		SINK_ENTRY_EX(1, (__uuidof(_IInaCalcProEvents)), 5, EvalCustomFunction)
		//SINK_ENTRY_EX(1, (__uuidof(_IInaCalcProEvents)), 6, AtomChanged)
	END_SINK_MAP()
};


int main()
{
	char name[50];
	cout << "put enter to start" << endl;
	cin >> name;
	cout << name << endl;

	CoInitialize(NULL);
	_Module.Init(NULL, (HINSTANCE)GetModuleHandle(NULL));

	IInaCalcProPtr m_pInaCalc;

	m_pInaCalc.CreateInstance(__uuidof(InaCalcPro), NULL, CLSCTX_INPROC_SERVER);
	//m_pInaCalc.CreateInstance(__uuidof(InaCalcPro));
	m_pInaCalc->put_AutoCalc(0);
	m_pInaCalc->put_RestrictVariables(TRUE);

	IInaCalcFuncsPtr  pInaCalcFuncs;
	m_pInaCalc->get_Funcs(&pInaCalcFuncs);

	IInaCalcFuncPtr  spInaCalcFn;
	BSTR bstrName = SysAllocString(_T("getarea")),
		bstrPrototype = SysAllocString(_T("SomeText")),
		bstrDesc = SysAllocString(_T("SomeText"));

	_bstr_t  sbName(bstrName, false);
	_bstr_t  sbPrototype(bstrPrototype, false);
	_bstr_t  sbDesc(bstrDesc, false);


	pInaCalcFuncs->raw_Add(sbName, inaFuncCustom, sbPrototype, sbDesc, &spInaCalcFn);


	CMSEquation* pReveiver = new CMSEquation;

	HRESULT hresult = pReveiver->DispEventAdvise(m_pInaCalc);

	IInaCalcAtomsPtr   spAtoms;
	m_pInaCalc->get_Atoms(&spAtoms);

	IInaCalcAtomPtr spAtomAll;
	CComVariant allEuqation(_T("all"));
	spAtoms->get_Item(allEuqation, &spAtomAll);

	CComVariant allVal(_T("12"));
	spAtomAll->putref_Value(allVal);

	CComVariant svEquation(_T("{0FCCC1AA-41F0-4ED3-BEA0-A6D61410B645}"));
	IInaCalcAtomPtr   spAtomEq;
	spAtoms->get_Item(svEquation, &spAtomEq);

	//BSTR m_equationFormula = SysAllocString(_T("1+1"));
	//CString  cstrEquation = m_equationFormula;
	//cstrEquation.MakeLower();
	//_bstr_t sbEquation(cstrEquation);

	//spAtomEq->put_Formula(sbEquation);
	//m_pInaCalc->Recalc();

	//_variant_t  svRes;
	//spAtomEq->get_Value(&svRes);
	//cout << "the result is " << svRes.intVal << endl;



	BSTR m_equationFormula = SysAllocString(_T("getarea(all,5)"));
	//BSTR m_equationFormula = SysAllocString(_T("1+2*3"));
	CString cstrEquation = m_equationFormula;
	cstrEquation.MakeLower();
	_bstr_t sbEquation(cstrEquation);
	spAtomEq->put_Formula(sbEquation);

	_bstr_t  sbSyntax;
	if (m_pInaCalc->LastError != inaErrNone)
	{
		sbSyntax = m_pInaCalc->LastErrorDescr;
		CString  cstrSyntax = (LPCTSTR)sbSyntax;
		CString  cstrFirst = _T("Syntax error in ");
		if (cstrSyntax.Left(cstrFirst.GetLength()) == cstrFirst)
			sbSyntax = (LPCTSTR)cstrSyntax.Right(cstrSyntax.GetLength() - cstrFirst.GetLength());
		else
		{
			int nPos = cstrSyntax.Find(cstrEquation);
			CString  cstrLast = _T(" in ");
			if (nPos != -1 && cstrSyntax.Right(cstrLast.GetLength()) == cstrLast)
			{
				// remove the ' in ' text
				sbSyntax = cstrSyntax.Left(nPos);
				sbSyntax += _T("\n");
				sbSyntax += (LPCTSTR)cstrEquation;
			}
			else
			{
				sbSyntax = cstrSyntax;
				sbSyntax += _T("\n");
			}
		}
	}

	m_pInaCalc->Recalc();

	_variant_t  svRes;
	spAtomEq->get_Value(&svRes);
	cout << "the result is " << svRes.dblVal << endl;


	pReveiver->DispEventUnadvise(m_pInaCalc);
	_Module.Term();
	CoUninitialize();


}

STDMETHODIMP_(HRESULT __stdcall) CMSEquation::CheckAtom(BSTR strAtom, EInaValueType* valType)
{
	return E_NOTIMPL;
}

STDMETHODIMP_(HRESULT __stdcall) CMSEquation::GetAtomValue(BSTR strAtom, VARIANT* vntValue)
{
	return E_NOTIMPL;
}

STDMETHODIMP_(HRESULT __stdcall) CMSEquation::ValueChanged(BSTR strAtom)
{
	return E_NOTIMPL;
}

STDMETHODIMP_(HRESULT __stdcall) CMSEquation::CheckCustomFunction(BSTR strFunc, IDispatch* argTypes, EInaValueType* valType)
{
	_bstr_t sbFunc(strFunc);

	BSTR  bstrName = SysAllocString(_T("getarea"));
	_bstr_t  sbName(bstrName, false);
	if (_wcsicmp(sbName, sbFunc) == 0)
	{
		IInaCalcFuncArgTypesPtr  pArgTypes(argTypes);
		long  nArgs;
		pArgTypes->get_Count(&nArgs);
		sbFunc += _T("(");
		EInaValueType  type;
		for (long ni = 0; ni < nArgs; ni++)
		{
			if (ni > 0)
				sbFunc += _T(",");
			pArgTypes->get_Item(ni + 1, &type);

			switch (type)
			{
			case inaValEmpty:
			case inaValError:
				sbFunc += g_typeEMPTY;
				break;
			case inaValText:
				sbFunc += g_typeBSTR;
				break;
			case inaValNumber:
				sbFunc += g_typeR8;
				break;
			case inaValDate:
				sbFunc += g_typeDATE;
				break;
			case inaValBool:
				sbFunc += g_typeBOOL;
				break;
			}
		}
		sbFunc += _T(")");
		cout << "checkCustomFunc is " << sbFunc << endl;
		return S_OK;
	}

	return E_NOTIMPL;
}

STDMETHODIMP_(HRESULT __stdcall) CMSEquation::EvalCustomFunction(BSTR strFunc, IDispatch* argVals, VARIANT* vntValue)
{
	if (vntValue == NULL)
		return E_POINTER;
	VariantInit(vntValue);

	_bstr_t sbFunc(strFunc);

	BSTR  bstrName = SysAllocString(_T("getarea"));
	_bstr_t  sbName(bstrName, false);
	if (_wcsicmp(sbName, sbFunc) == 0)
	{
		IInaCalcFuncArgValsPtr  pArgVals(argVals);
		long  nArgs;
		pArgVals->get_Count(&nArgs);
		sbFunc += _T("(");
		TCHAR szBuffer[32];
		for (long ni = 0; ni < nArgs; ni++)
		{
			if (ni > 0)
				sbFunc += _T(",");
			_variant_t  type;
			pArgVals->get_Item(ni + 1, &type);
			szBuffer[0] = _T('\0');
			_bstr_t  sbValue;
			switch (type.vt)
			{
			case VT_R8:
				swprintf_s(szBuffer, _T("%.14g"), type.dblVal);
				break;
			case VT_I4:
				swprintf_s(szBuffer, _T("%d"), type.lVal);
				break;
			case VT_BOOL:
				swprintf_s(szBuffer, _T("%d"), type.boolVal);
				break;
			}
			if (type.vt == VT_BSTR)
				sbFunc += type.bstrVal;
			else
				sbFunc += szBuffer;
		}
		sbFunc += _T(")");

		cout << "evalCustomFunc is " << sbFunc << endl;

		double area = 5.0 * 6;
		vntValue->vt = VT_R8;
		vntValue->dblVal = area;
		return S_OK;
	}
}

