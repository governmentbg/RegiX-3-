<?xml version="1.0" encoding="UTF-8"?>
<!--Designed and generated by Altova StyleVision Enterprise Edition 2008 rel. 2 sp1 - see http://www.altova.com/stylevision for more information.-->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:common="http://egov.bg/RegiX/NCPR/Common" xmlns:fn="http://www.w3.org/2005/xpath-functions" xmlns:n1="http://egov.bg/RegiX/NCPR/MedicinalProducts/GetRegisterMedicinalProductDataResponse" xmlns:xdt="http://www.w3.org/2005/xpath-datatypes" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:altova="http://www.altova.com">
	<xsl:output version="4.0" method="html" indent="no" encoding="UTF-8" doctype-public="-//W3C//DTD HTML 4.0 Transitional//EN" doctype-system="http://www.w3.org/TR/html4/loose.dtd"/>
	<xsl:param name="SV_OutputFormat" select="'HTML'"/>
	<xsl:variable name="XML" select="/"/>
	<xsl:template match="/">
		<html>
			<head>
				<title/>
			</head>
			<body>
				<xsl:for-each select="$XML">
					<h1 align="center">
						<span>
							<xsl:text>Справка по Извличане на детайли за лекарствен продукт в конкретен регистър</xsl:text>
						</span>
					</h1>
					<xsl:for-each select="n1:GetRegisterMedicinalProductDataResponse">
						<xsl:for-each select="n1:MedicinalProductData">
							<xsl:for-each select="common:MedicinalProductIdentifier">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Национален номер за идентификация на лекарствен продукт: </xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:NameBG">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Наименование на лекарствен продукт (BG):</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:NameEN">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Наименование на лекарствен продукт (EN):</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:INN">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Международно непатентно наименование /INN/:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:AuthorizationHolder">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Притежател на разрешение за употреба: </xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:AuthorizationNumber">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>№ на разрешение за употреба / Регистрационен номер:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:MedicamentForm">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Лекарствена форма: </xsl:text>
								</span>
								<span style="font-weight:bold; ">
									<xsl:apply-templates/>
								</span>
							</xsl:for-each>
							<xsl:for-each select="common:Quantity">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Количество на активното лекарствено вещество:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:MedicamentUnit">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Мерна единица:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:FinalPack">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Окончателна опаковка: </xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:Producer">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Производител:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:ProducerDeclaredPrice">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Цена на производител: </xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:ProducerPriceCurrency">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Валута на цена на производител:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:ProducerPriceExchangeRate">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Обменен курс:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:ProducerPrice">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Цена на производител в лв.:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:ProducerVat">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>ДДС на производител, лв.:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:ProducerFinalPriceBGN">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Цена на производител с ДДС, лв.:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:MerchantMarginPercent">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Надценка Търговец на едро, %:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:MerchantMarginValue">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Надценка Търговец на едро, лв.:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:MerchantPriceNoVat">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Цена Търговец на едро без ДДС, лв.:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:MerchantVat">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>ДДС на търговец на едро, лв.:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:MerchantFinalPriceBGN">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Цена Търговец на едро с ДДС, лв.:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:RetailerMarginPercent">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Надценка Търговец на дребно, %:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:RetailerMarginValue">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Надценка Търговец на дребно, лв.:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:RetailerPriceNoVat">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Цена Търговец на дребно без ДДС, лв.:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:RetailerVat">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>ДДС на търговец на дребно, лв.:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<xsl:for-each select="common:RetailerFinalPriceBGN">
								<br/>
								<span style="font-weight:bold; ">
									<xsl:text>Цена Търговец на дребно с ДДС, лв.:</xsl:text>
								</span>
								<span>
									<xsl:text>&#160;</xsl:text>
								</span>
								<xsl:apply-templates/>
							</xsl:for-each>
							<br/>
							<xsl:for-each select="common:MedicinalProductPDLRegistersData">
								<h3>
									<span>
										<xsl:text>Данни за лекарствен продукт в Позитивен лекарствен списък: </xsl:text>
									</span>
								</h3>
								<xsl:for-each select="common:MedicinalProductPDLRegisterData">
									<span>
										<xsl:text>Запис </xsl:text>
									</span>
									<span>
										<xsl:value-of select="position()"/>
									</span>
									<xsl:for-each select="common:RegisterName">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Наименование на регистър:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:PublishedAt">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Дата на настъпили промени в обстоятелствата: </xsl:text>
										</span>
										<span>
											<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
											<xsl:text>.</xsl:text>
											<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
											<xsl:text>.</xsl:text>
											<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
										</span>
										<span>
											<xsl:text> г.</xsl:text>
										</span>
									</xsl:for-each>
									<xsl:for-each select="common:МaximumPrice">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Максимална цена:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:RegisterCode">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Уникален код на регистър:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:Group">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Група ЛП:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:ReimbursementPercent">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Ниво на заплащане в %:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:ReimbursementValue">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Ниво на заплащане, стойност:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:DDDValue">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Препоръчителна дневна доза /DDD/ /терапевтичен курс: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:DDDUnit">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Мерна единица</xsl:text>
										</span>
										<span>
											<xsl:text>:</xsl:text>
										</span>
										<span style="font-weight:bold; ">
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:DDDReferentValue">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Референтна стойност за DDD/ Терапевтичен курс:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:PackDDDNumber">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Брой дневни дози в опаковка:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:IsDddWHO">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Дали Референтна стойност за DDD/ Терапевтичен курс e по СЗО/WHO: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:PackPriceRefDDD">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Стойност за опаковка, изчислена на база референтна стойност: </xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:PrescriptionRestrictions">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Терапевтични показания / Ограничение в начина на предписване при различни индикации:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:AverageTreatmentPeriod">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Средна продължителност на лечението:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:ConcomitantTreatmentSpecifics">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Особеност на дозировката и средна продължителност на лечението:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:TreatmentSpecifics">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Необходимост от съпровождащо лечение:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:ATCCodes">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Анатомо-терапевтични кодове /ATC-кодове/: </xsl:text>
										</span>
										<ul>
											<xsl:for-each select="common:ATCCode">
												<li>
													<xsl:apply-templates/>
												</li>
											</xsl:for-each>
										</ul>
									</xsl:for-each>
									<xsl:for-each select="common:ICDCodes">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>МКБ кодове: </xsl:text>
										</span>
										<ul>
											<xsl:for-each select="common:ICDCode">
												<li>
													<xsl:apply-templates/>
												</li>
											</xsl:for-each>
										</ul>
									</xsl:for-each>
									<br/>
									<hr/>
									<br/>
								</xsl:for-each>
							</xsl:for-each>
							<xsl:for-each select="common:MedicinalProductCeilingPricesRegisterData">
								<br/>
								<h3>
									<span>
										<xsl:text>Данни за лекарствен продукт в Регистър на пределните цени: </xsl:text>
									</span>
								</h3>
								<br/>
								<xsl:for-each select="common:MedicinalProductCeilingPriceRegisterData">
									<span>
										<xsl:text>Запис </xsl:text>
									</span>
									<span>
										<xsl:value-of select="position()"/>
									</span>
									<xsl:for-each select="common:PublishedAt">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Дата на настъпили промени в обстоятелствата:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<span>
											<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
											<xsl:text>.</xsl:text>
											<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
											<xsl:text>.</xsl:text>
											<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
										</span>
										<span>
											<xsl:text> г.</xsl:text>
										</span>
									</xsl:for-each>
									<xsl:for-each select="common:RegisterName">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Наименование на регистър:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:RegisterCode">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Уникален код на регистър:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<br/>
									<hr/>
								</xsl:for-each>
							</xsl:for-each>
							<xsl:for-each select="common:MedicinalProductMaxPricesRegisterData">
								<br/>
								<h3>
									<span>
										<xsl:text>Данни за лекарствен продукт в Регистър на максималните продажни цени:</xsl:text>
									</span>
								</h3>
								<br/>
								<xsl:for-each select="common:MedicinalProductMaxPriceRegisterData">
									<span>
										<xsl:text>Запис </xsl:text>
									</span>
									<span>
										<xsl:value-of select="position()"/>
									</span>
									<xsl:for-each select="common:PublishedAt">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Дата на настъпили промени в обстоятелствата:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<span>
											<xsl:value-of select="format-number(number(substring(string(string(.)), 9, 2)), '00')"/>
											<xsl:text>.</xsl:text>
											<xsl:value-of select="format-number(number(substring(string(string(.)), 6, 2)), '00')"/>
											<xsl:text>.</xsl:text>
											<xsl:value-of select="format-number(number(substring(string(string(string(.))), 1, 4)), '0000')"/>
										</span>
										<span>
											<xsl:text> г.</xsl:text>
										</span>
									</xsl:for-each>
									<xsl:for-each select="common:RegisterName">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Наименование на регистър:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:RegisterCode">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Уникален код на регистър:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<xsl:for-each select="common:MaximumPrice">
										<br/>
										<span style="font-weight:bold; ">
											<xsl:text>Максимална цена:</xsl:text>
										</span>
										<span>
											<xsl:text>&#160;</xsl:text>
										</span>
										<xsl:apply-templates/>
									</xsl:for-each>
									<br/>
									<hr/>
								</xsl:for-each>
							</xsl:for-each>
						</xsl:for-each>
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>