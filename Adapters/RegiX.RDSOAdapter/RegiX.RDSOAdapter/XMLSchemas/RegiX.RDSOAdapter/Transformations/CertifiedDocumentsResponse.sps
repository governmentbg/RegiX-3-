<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="common" uri="http://egov.bg/RegiX/MOMN/RDSO"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/MOMN/RDSO/CertifiedDocumentsResponse"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\eGov\RegiX\RegiX.RDSOAdapter\XMLSchemas\CertifiedDocumentsResponse.xsd" workingxmlfile="CertifiedDocumentsResponse.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:CertifiedDocumentsResponse" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<newline/>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Министерство на образованието и науката"/>										</children>									</paragraph>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Регистър на дипломи и свидетелства за завършено основно и средно образование и придобита степен на професионална квалификация"/>										</children>									</paragraph>									<paragraph paragraphtag="h2">										<properties align="center"/>										<children>											<text fixtext="Справка за вписани в регистъра заверки на образователни документи"/>											<condition>												<children>													<conditionbranch xpath="count( n1:GenerationTimeStamp ) &gt; 0">														<children>															<text fixtext=" към дата "/>															<template match="n1:GenerationTimeStamp" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<content>																		<format string="DD.MM.YYYY"/>																	</content>																</children>															</template>														</children>													</conditionbranch>													<conditionbranch/>												</children>											</condition>											<text fixtext=" "/>										</children>									</paragraph>									<condition>										<children>											<conditionbranch xpath="count( n1:CertifiedDocument ) &gt; 0">												<children>													<template match="n1:CertifiedDocument" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<newline/>															<text fixtext="Документ "/>															<autocalc xpath="position()"/>															<text fixtext=" от "/>															<autocalc xpath="count(../n1:CertifiedDocument)"/>															<newline/>															<table>																<properties border="1" width="100%"/>																<children>																	<tablebody>																		<children>																			<tablerow>																				<children>																					<tablecell>																						<children>																							<text fixtext="Идентификатор на документа; служебно поле"/>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="common:intID" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content/>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																			<tablerow>																				<children>																					<tablecell>																						<children>																							<condition>																								<children>																									<conditionbranch xpath="common:IDType = &apos;EGN&apos; or  common:IDType = &apos;ЕГН&apos;">																										<children>																											<text fixtext="ЕГН"/>																										</children>																									</conditionbranch>																									<conditionbranch xpath="common:IDType  = &apos;LNCh&apos; or  common:IDType = &apos;ЛНЧ&apos;">																										<children>																											<text fixtext="ЛНЧ"/>																										</children>																									</conditionbranch>																									<conditionbranch xpath="common:IDType  = &apos;IDN&apos; or  common:IDType = &apos;ИДН&apos;">																										<children>																											<text fixtext="Служебен номер на ученика / студента"/>																										</children>																									</conditionbranch>																									<conditionbranch>																										<children>																											<text fixtext="Идентификатор на ученика"/>																										</children>																									</conditionbranch>																								</children>																							</condition>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="common:intStudentID" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content/>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																			<tablerow>																				<children>																					<tablecell>																						<children>																							<text fixtext="Име на ученика"/>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="common:vcName1" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content/>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																			<tablerow>																				<children>																					<tablecell>																						<children>																							<text fixtext="Презиме на ученика"/>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="common:vcName2" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content/>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																			<tablerow>																				<children>																					<tablecell>																						<children>																							<text fixtext="Фамилия на ученика"/>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="common:vcName3" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content/>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																			<tablerow>																				<children>																					<tablecell>																						<children>																							<text fixtext="Код на документа"/>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="common:intDocumentType" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content/>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																			<tablerow>																				<children>																					<tablecell>																						<children>																							<text fixtext="Наименование на документа"/>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="common:vcDocumentName" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content/>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																			<tablerow>																				<children>																					<tablecell>																						<children>																							<text fixtext="Серия на документа"/>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="common:vcPrnSer" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content/>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																			<tablerow>																				<children>																					<tablecell>																						<children>																							<text fixtext="Номер на документа"/>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="common:vcPrnNo" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content/>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																			<tablerow>																				<children>																					<tablecell>																						<children>																							<text fixtext="Регистрационен номер на документа"/>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="common:vcRegNo" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content/>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																			<tablerow>																				<children>																					<tablecell>																						<children>																							<text fixtext="Дата на заверка на документа"/>																						</children>																					</tablecell>																					<tablecell>																						<children>																							<template match="common:dtCertDate" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format string="DD.MM.YYYY"/>																									</content>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</tablebody>																</children>															</table>															<newline/>															<template match="common:DocumentImages" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<newline/>																	<condition>																		<children>																			<conditionbranch xpath="count(../.) &gt; 0">																				<children>																					<text fixtext="Диплома"/>																				</children>																			</conditionbranch>																		</children>																	</condition>																	<newline/>																	<paragraph>																		<children>																			<template match="common:DocumentImage" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<image>																						<properties height="900px"/>																						<target>																							<xpath value="concat(&quot;data:image/png;base64,&quot;, string(.))"/>																						</target>																						<imagesource>																							<xpath value="concat(&quot;data:image/png;base64,&quot;, string(.))"/>																						</imagesource>																					</image>																					<newline/>																					<newline/>																				</children>																			</template>																		</children>																	</paragraph>																</children>															</template>															<newline/>														</children>													</template>												</children>											</conditionbranch>											<conditionbranch>												<children>													<text fixtext="Няма намерени данни в Регистърът на дипломи и свидетелства за завършено основно и средно образование и придобита степен на професионална квалификация по търсените критерии."/>												</children>											</conditionbranch>										</children>									</condition>									<newline/>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>